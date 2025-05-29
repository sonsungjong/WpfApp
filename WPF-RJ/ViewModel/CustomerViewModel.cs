using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WPF_RJ.Model;

namespace WPF_RJ.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        //private ObservableCollection<TableDataModel> m_table_data_list;                             // 450 ~ 500ms (100000개)
        private RangeObservableCollection<TableDataModel> m_table_data_list;                    // 30 ~ 50ms (100000개), 약 10배

        //public ObservableCollection<TableDataModel> TableDataList
        public RangeObservableCollection<TableDataModel> TableDataList
        {
            get { return m_table_data_list; }
            set
            {
                if(m_table_data_list != value)
                {
                    m_table_data_list = value;
                    OnPropertyChanged(nameof(TableDataList));
                }
            }
        }

        private string _headerNo = "No";
        public string HeaderNo
        {
            get => _headerNo;
            set { _headerNo = value; OnPropertyChanged(nameof(HeaderNo)); }
        }

        private string _headerName = "Name";
        public string HeaderName
        {
            get => _headerName;
            set { _headerName = value; OnPropertyChanged(nameof(HeaderName)); }
        }

        private string _headerInfo = "Info";
        public string HeaderInfo
        {
            get => _headerInfo;
            set {
                _headerInfo = value; 
                OnPropertyChanged(nameof(HeaderInfo)); }
        }

        public int test_count = 10;
        private bool m_isKoreanHeader = false;

        // 헤더 정보를 바꿈
        private void ExecuteImageButtonChangeHeaderCommand(object obj)
        {
            if (!m_isKoreanHeader)
            {
                HeaderNo = "번호";
                HeaderName = "이름";
                HeaderInfo = "정보";
            }
            else
            {
                HeaderNo = "No";
                HeaderName = "Name";
                HeaderInfo = "Info";
            }
            m_isKoreanHeader = !m_isKoreanHeader;
        }

        // 버튼 ICommand 생성
        public ICommand ImageButtonCommand { get; set; }
        public ICommand ImageButtonChangeHeaderCommand { get; set; }

        // 생성자
        public CustomerViewModel()
        {
            // ICommand 적용
            ImageButtonCommand = new ViewModelCommand(ExecuteImageButtonCommand);           // 다이아몬드 버튼 (임시)
            ImageButtonChangeHeaderCommand = new ViewModelCommand(ExecuteImageButtonChangeHeaderCommand);           // 다이아몬드 버튼 (임시)

            // 데이터그리드 생성
            //TableDataList = new ObservableCollection<TableDataModel>();
            TableDataList = new RangeObservableCollection<TableDataModel>();

            // 빈 행 30개
            for(int i = 0; i < 30; i++)
            {
                TableDataList.Add(new TableDataModel { No = "", Name = "", Info = "" });
            }
        }

        

        // 데이터를 바꿈
        private void ExecuteImageButtonCommand(object obj)
        {
            test_count++;
            //for (int test=0; test<test_count; test++)
            {
                //Stopwatch sw = Stopwatch.StartNew();                // 디버깅 : Stopwatch 시작

                //var newList = new List<TableDataModel>();
                //var newDict = new SortedDictionary<int, List<TableDataModel>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));              // 특정키로 정렬이 필요할 때 (오름차순)
                //var newDict = new SortedDictionary<int, List<TableDataModel>>();                // 특정키로 정렬이 필요할 때 (내림차순)
                //newDict[1] = new List<TableDataModel>();
                //newDict[2] = new List<TableDataModel>();
                //newDict[3] = new List<TableDataModel>();
                var newOnlyDict = new Dictionary<int, TableDataModel>();

                int total = 100000;
                //int rank1 = total / 3;
                //int rank2 = (2*total) / 3;

                for (int i = 1; i <= total; i++)
                {
                    //int rank = 0;
                    //if(i <= rank1)
                    //{
                    //    rank = 1;
                    //}
                    //else if(i <= rank2)
                    //{
                    //    rank = 2;
                    //}
                    //else
                    //{
                    //    rank = 3;
                    //}

                    string no = i.ToString();
                    string name;
                    string info;

                    if(test_count % 2 == 0)
                    {
                        name = "DATA " + no;
                        info = "SAMPLE " + no;
                    }
                    else
                    {
                        name = "데이터 " + no;
                        info = "샘플 " + no;
                    }

                    // ObservableCollection
                    //TableDataModel newData = new TableDataModel { No = no, Name = name, Info = info };
                    //TableDataList.Add(newData);

                    // RangeObservableCollection
                    // 리스트
                    //newList.Add(new TableDataModel { No = no, Name = name, Info = info });              // 리스트에 담아놓고
                    // 딕셔너리 (rank로 정렬)
                    //newDict[rank].Add(new TableDataModel { No = no, Name = name, Info = info });                // 딕셔너리에 담아놓고
                    // 그냥 딕셔너리
                    newOnlyDict[i] = new TableDataModel { No = no, Name = name, Info = info };               // 딕셔너리에 담고
                }
                // 일괄 적용한다
                //Application.Current.Dispatcher.Invoke(() =>
                //{
                    //TableDataList.ChangeRange(newList);                  // 리스트 사용시
                    //TableDataList.ChangeRange(newDict);                    // 딕셔너리 사용 시 (SortedDictionary 포함)
                    //TableDataList.ChangeRange(newOnlyDict);                    // 딕셔너리 사용 시 (SortedDictionary 포함)

                    var tempList = new RangeObservableCollection<TableDataModel>();
                    tempList.ChangeRange(newOnlyDict);
                    TableDataList = tempList;
                //});



                // 소요 시간 출력
                //sw.Stop();                // 디버깅 : Stopwatch 정지
                //MessageBox.Show($"데이터 추가에 걸린 시간: {sw.ElapsedMilliseconds} ms", "성능 측정");                // 디버깅 : 성능 측정
            }
        }
    }
}
