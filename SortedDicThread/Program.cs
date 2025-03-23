using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/*
    빠른 속도로 구조체(시간long + 아이디(int) + 메시지)를 세이프큐에 집어넣는다 (0.10초에 한번씩)
    스레드풀은 세이프큐에 담기는대로 꺼내서 전처리를 한다 (이때, 전처리 로직이 메시지 아이디별로 달라 시간이 다르게 걸린다 0.15초, 0.30초, 0.10초)
    전처리 후 시간이 작은 순서대로 정렬할 수 있도록 동기화된 SortedDictionary 에 넣는다
    하나의 스레드에서 SortedDictionary를 RemoveAll로 가져가서
    가져온 딕셔너리를 순차적으로 0.10초에 하나씩 번호와 메시지를 출력한다

    세이프큐가 쌓이는 것은 파싱 속도가 늦다는 것 (쓰레드 추가 필요)
    딕셔너리가 쌓이는 것은 UI쓰레드 처리 경량화가 필요
    
    결과론적으로 안녕하세요->반갑습니다->행복하세요
    가 순서대로 계속 나와야한다
*/


namespace SortedDicThread
{
    class Program
    {
        public interface IMsg {
            //ulong Time { get; set; }
        }

        // 처리시간 0.2초
        public struct ST_Msg1 : IMsg
        {
            public ulong time;               // 스레드풀에 담은 현재시간
            public uint id;                     // 멤버변수값을 저장 (저장 후 멤버변수는 ++)
            public string msg;              // 안녕하세요
            public byte dump;
        }               // 가장 먼저 쓰레드풀에 넣는다 (x % 3 == 0)

        // 처리시간 0.3초
        public struct ST_Msg2 : IMsg
        {
            public ulong time;               // 스레드풀에 담은 현재시간
            public uint id;                     // 멤버변수값을 저장 (저장 후 멤버변수는 ++)
            public string msg;              // 반갑습니다
            public short dump;
        }               // 두번째로 쓰레드풀에 넣는다 (x % 3 == 1)

        // 처리시간 0.1초
        public struct ST_Msg3 : IMsg
        {
            public ulong time;               // 스레드풀에 담은 현재시간
            public uint id;                     // 멤버변수값을 저장 (저장 후 멤버변수는 ++)
            public string msg;              // 좋은하루되세요
            public int dump;
        }               // 세번째로 쓰레드풀에 넣는다 (x % 3 == 2)

        public class ConcurrentSortedList
        {
            private SortedList<ulong, ulong> _list = new SortedList<ulong, ulong>();
            private readonly object _lock = new object();

            public void Add(ulong value)
            {
                lock(_lock)
                {
                    if (!_list.ContainsKey(value))
                    {
                        _list.Add(value, value);
                    }
                }
            }

            // 첫 번째(최소) 시간 값을 반환 (없으면 null)
            public ulong? First
            {
                get
                {
                    lock (_lock)
                    {
                        return _list.Count > 0 ? _list.Keys[0] : (ulong?)null;
                    }
                }
            }

            // 특정 시간 값을 제거
            public bool Remove(ulong value)
            {
                lock (_lock)
                {
                    return _list.Remove(value);
                }
            }

            // 현재 저장된 모든 시간값의 스냅샷을 반환
            public List<ulong> GetSnapshot()
            {
                lock (_lock)
                {
                    return _list.Values.ToList();
                }
            }

            // 현재 저장된 항목 수
            public int Count
            {
                get { lock (_lock) { return _list.Count; } }
            }
        }

        // 동기화된 SortedDictionary 구현
        // key: ulong (시간) / value: IMyMsg
        public class ConcurrentSortedDictionary
        {
            private SortedDictionary<ulong, IMsg> _dict = new SortedDictionary<ulong, IMsg>();              // 정렬 딕셔너리 (송수신 시간 기준으로 정렬)
            private readonly object _lock = new object();

            public void Add1(IMsg msg)
            {
                lock (_lock)
                {
                    ulong key = ((ST_Msg1)msg).time;
                    _dict.Add(key, msg);
                }
            }

            public void Add2(IMsg msg)
            {
                lock (_lock)
                {
                    ulong key = ((ST_Msg2)msg).time;
                    _dict.Add(key, msg);
                }
            }

            public void Add3(IMsg msg)
            {
                lock (_lock)
                {
                    ulong key = ((ST_Msg3)msg).time;
                    _dict.Add(key, msg);
                }
            }

            // 전체 내용을 제거하지 않고 복사만 함
            public List<IMsg> GetAll()
            {
                lock (_lock)
                {
                    return _dict.Values.ToList();
                }
            }

            // 모든 항목을 한 번에 가져오고 내부 컬렉션을 비웁니다.
            public List<IMsg> RemoveAll()
            {
                lock (_lock)
                {
                    var snapshot = _dict.Values.ToList();
                    _dict.Clear();
                    return snapshot;
                }
            }

            // 현재 저장된 항목 수 반환
            public int Count
            {
                get { lock (_lock) { return _dict.Count; } }
            }

            public static ulong GetTime(IMsg msg)
            {
                if (msg is ST_Msg1 m1)
                {
                    return m1.time;
                }
                else if (msg is ST_Msg2 m2)
                {
                    return m2.time;
                }
                else if (msg is ST_Msg3 m3)
                {
                    return m3.time;
                }
                else
                {
                    throw new ArgumentException("알 수 없는 메시지 타입입니다.", nameof(msg));
                }
            }

        }

        static void Main(string[] args)
        {
            // 세이프큐에 새 메시지가 들어왔음을 알리기 위한 AutoResetEvent (초기 신호 없음)
            AutoResetEvent m_eventNewQueueMessage = new AutoResetEvent(false);
            AutoResetEvent m_eventNewDictMessage = new AutoResetEvent(false);

            // 수신스레드가 넣고 스레드풀이 가져다 사용할 세이프큐
            ConcurrentQueue<IMsg> safeQueue = new ConcurrentQueue<IMsg>();

            // 스레드풀 처리 후 정렬이 필요한 메시지를 담을 딕셔너리
            ConcurrentSortedDictionary sortedDict = new ConcurrentSortedDictionary();
            ConcurrentSortedList sortedTimeList = new ConcurrentSortedList();

            CancellationTokenSource cts_recv = new CancellationTokenSource();
            CancellationTokenSource cts_threadpool = new CancellationTokenSource();
            CancellationTokenSource cts_ui = new CancellationTokenSource();

            // 전처리 파싱 작업 생성 (사전대기) : 스레드풀의 여러 작업이 safeQueue에서 메시지를 꺼내 전처리 후 sortedDict에 추가 (아이디별로 걸리는 시간 다름)
            int parsingTaskCount = Environment.ProcessorCount;
            Task[] processingTasks = new Task[parsingTaskCount];
            for (int i = 0; i < parsingTaskCount; i++)
            {
                processingTasks[i] = Task.Run(() =>
                {
                    while (!cts_threadpool.Token.IsCancellationRequested)
                    {
                        if (safeQueue.TryDequeue(out IMsg msg))
                        {
                            // 메시지 타입별 전처리 지연시간 적용
                            if (msg is ST_Msg1 m1)
                            {
                                sortedTimeList.Add(m1.time);                // 처리 전에 가장 먼저 시간을 기록한다 (공통)
                                Thread.Sleep(150);                      // 0.15초 처리
                                sortedDict.Add1(m1);
                                m_eventNewDictMessage.Set();
                            }
                            else if (msg is ST_Msg2 m2)
                            {
                                sortedTimeList.Add(m2.time);                // 처리 전에 가장 먼저 시간을 기록한다 (공통)
                                Thread.Sleep(300);                      // 0.30초 처리
                                sortedDict.Add2(m2);
                                m_eventNewDictMessage.Set();
                            }
                            else if (msg is ST_Msg3 m3)
                            {
                                sortedTimeList.Add(m3.time);                // 처리 전에 가장 먼저 시간을 기록한다 (공통)
                                Thread.Sleep(100);                      // 0.10초 처리
                                sortedDict.Add3(m3);
                                m_eventNewDictMessage.Set();
                            }
                        }
                        else
                        {
                            // 메시지가 없으면 대기
                            //m_eventNewQueueMessage.WaitOne();
                            int signaledIndex = WaitHandle.WaitAny(new WaitHandle[] { m_eventNewQueueMessage, cts_threadpool.Token.WaitHandle });
                            if (signaledIndex == 1)
                            {
                                break;
                            }
                        }
                    }
                }, cts_threadpool.Token);
            }

            // 딕셔너리에서 꺼내서 사용할 쓰레드 추가 미리 생성 (1개)
            // 소비자 작업: 단일 스레드가 SortedDictionary에서 RemoveAll로 가져와 0.1초 간격으로 하나씩 출력
            Task consumerTask = Task.Run(() =>
            {
                // 소비자 내부 버퍼
                List<IMsg> consumerBuffer = new List<IMsg>();

                while (!cts_ui.Token.IsCancellationRequested)
                {
                    // 딕셔너리에서 새 메시지를 제거하면서 가져옴
                    List<IMsg> newBatch = sortedDict.RemoveAll();
                    if (newBatch.Count > 0)
                    {
                        // 새 배치를 내부 버퍼에 추가
                        consumerBuffer.AddRange(newBatch);
                    }
                    else
                    {
                        //m_eventNewDictMessage.WaitOne();
                        int signaledIndex = WaitHandle.WaitAny(new WaitHandle[] { m_eventNewDictMessage, cts_ui.Token.WaitHandle });
                        if (signaledIndex == 1)
                        {
                            break;
                        }
                        continue;
                    }

                    // 소비자 버퍼를 생산 시점의 시간(생산자가 기록한 timeList 값)을 기준으로 정렬
                    consumerBuffer = consumerBuffer.OrderBy(m => ConcurrentSortedDictionary.GetTime(m)).ToList();

                    // 예상 생산 시간은 별도의 ConcurrentSortedList(timeList)의 첫 번째 값
                    ulong? expectedTime = sortedTimeList.First; // 스레드 안전하게 접근
                    if (expectedTime == null)
                    {
                        Thread.Sleep(20);
                        continue;
                    }

                    // 버퍼의 첫 메시지의 생산 시간
                    ulong actualTime = ConcurrentSortedDictionary.GetTime(consumerBuffer.First());

                    if (actualTime == expectedTime.Value)
                    {
                        // 예상과 일치하면 해당 메시지를 출력하고, 
                        // 소비자 버퍼에서 제거하며, timeList에서도 제거
                        IMsg msg = consumerBuffer.First();
                        consumerBuffer.RemoveAt(0);
                        sortedTimeList.Remove(expectedTime.Value);

                        uint id = 0;
                        string text = "";
                        if (msg is ST_Msg1 m1) { id = m1.id; text = m1.msg; }
                        else if (msg is ST_Msg2 m2) { id = m2.id; text = m2.msg; }
                        else if (msg is ST_Msg3 m3) { id = m3.id; text = m3.msg; }
                        Console.WriteLine($"[{id}] {text}{actualTime}");
                        Thread.Sleep(50); // 0.05초 간격 출력
                    }
                    else
                    {
                        // 예상과 불일치하면, 이미 가져온 consumerBuffer와 추가로 딕셔너리에서 제거한 새로운 배치를
                        // 합쳐서 전체 버퍼를 재정렬한 후 재검증 (여기서는 단순히 재시도)
                        //Console.WriteLine($"[소비자] 예상 시간 {expectedTime.Value}와 실제 {actualTime} 불일치. 버퍼를 재정렬 후 재시도");
                        // 이때, consumerBuffer는 그대로 유지하며, 잠시 대기 후 다시 루프를 돌면서 추가 메시지를 가져오게 함
                        Thread.Sleep(20);
                    }

                    // 사이즈 확인
                    int sizeQueue = safeQueue.Count;
                    int sizeDict = consumerBuffer.Count;
                    if (sizeQueue >= 8)
                    {
                        // 세이프큐가 쌓이는 것은 파싱 속도가 늦다는 것(쓰레드 추가 필요)
                        Console.WriteLine($"[세이프큐] 사이즈: {sizeQueue}");
                    }
                    if (sizeDict >= 8)
                    {
                        // 딕셔너리가 쌓이는 것은 UI쓰레드 처리 경량화가 필요
                        Console.WriteLine($"[딕셔너리] 사이즈: {sizeDict}");
                    }
                }
            }, cts_ui.Token);

            // 이제 생산자가 보내기 시작하자
            // 단일 생산자: 0.01초마다 메시지를 생성하여 safeQueue에 Enqueue
            uint counter = 0;
            Task producerTask = Task.Run(() =>
            {
                while (!cts_recv.Token.IsCancellationRequested)
                {
                    ulong now = (ulong)DateTime.UtcNow.Ticks;
                    IMsg msg;
                    uint _id = counter % 3;
                    if (_id == 0)
                    {
                        ST_Msg1 m = new ST_Msg1();
                        m.time = now;
                        m.id = _id;
                        m.msg = "안녕하세요";
                        m.dump = 0;
                        msg = m;
                    }
                    else if (_id == 1)
                    {
                        ST_Msg2 m = new ST_Msg2();
                        m.time = now;
                        m.id = _id;
                        m.msg = "반갑습니다    ";
                        m.dump = 0;
                        msg = m;
                    }
                    else
                    {
                        ST_Msg3 m = new ST_Msg3();
                        m.time = now;
                        m.id = _id;
                        m.msg = "행복하세요        ";
                        m.dump = 0;
                        msg = m;
                    }
                    counter++;
                    safeQueue.Enqueue(msg);
                    m_eventNewQueueMessage.Set();                    // 새 메시지가 들어왔으므로 이벤트 신호 설정
                    Thread.Sleep(100); // 0.10초 대기
                }
            }, cts_recv.Token);

            while (true)
            {
                // x키를 누르면 즉시 종료
                if (Console.ReadKey(true).KeyChar == 'x')
                {
                    cts_recv.Cancel();
                    cts_threadpool.Cancel();
                    cts_ui.Cancel();
                    break;
                }
            }

            try
            {
                m_eventNewQueueMessage.Set();
                m_eventNewDictMessage.Set();
                //Environment.Exit(0);                    // 강제 종료
                Task.WaitAll(new Task[] { producerTask, consumerTask }.Concat(processingTasks).ToArray());
            }
            catch (AggregateException) 
            { }

            Console.WriteLine("\n종료합니다\n");
        }               // main
    }
}
