using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UITCC.Model
{
    public class ConnectionStatusModel
    {
        private readonly int _port = 23456;
        private IPAddress localAddress;
        private Thread _udp_server_thread;

        // C2 연결 상태
        public bool ConnectionC2 { get; set; }
        public bool ConnectionBN { get; set; }

        // 싱글턴 패턴
        private static ConnectionStatusModel _instance;
        public static ConnectionStatusModel Instance => _instance ?? (_instance = new ConnectionStatusModel());

        // 생성자
        private ConnectionStatusModel()
        {
            // 처음 상태는 모두 false
            ConnectionC2 = false;
            ConnectionBN = false;

            // UDP 서버 시작
            StartUDPServer();
        }

        public void StartUDPServer()
        {
            _udp_server_thread = new Thread(RunServer);
            _udp_server_thread.IsBackground = true;             // 애플리케이션이 종료될 때 쓰레드도 종료시킨다
            _udp_server_thread.Start();             // 서버 시작
        }

        private void RunServer()
        {
            localAddress = IPAddress.Any;
            UdpClient udpClient = new UdpClient();
            udpClient.ExclusiveAddressUse = false;
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, _port));
            string client_ip = "";
            string c2s_ip = "172.16.1.157";
            string bns_ip = "172.16.1.175";

            // 타임아웃을 3초로 설정
            udpClient.Client.ReceiveTimeout = 3000;

            while(true)
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, _port);

                try
                {
                    // 수신
                    byte[] data = udpClient.Receive(ref remoteEP);

                    client_ip = remoteEP.Address.ToString();
                    string msg = Encoding.Unicode.GetString(data);

                    // 수신 후 송신
                    byte[] response = Encoding.Unicode.GetBytes(client_ip + " : " + msg + "를 받았습니다");
                    udpClient.Send(response, response.Length, remoteEP);

                    if(client_ip == "172.16.1.157")
                    {
                        // C2 Simulator
                        ConnectionC2 = true;
                    }else if (client_ip == "172.16.1.175")
                    {
                        ConnectionBN = true;
                    }
                }catch(SocketException e)
                {
                    // 3초를 초과
                    if(e.SocketErrorCode == SocketError.TimedOut && client_ip == "172.16.1.175")
                    {
                        ConnectionBN = false;
                    }
                    else if(e.SocketErrorCode == SocketError.TimedOut && client_ip == "172.16.1.157")
                    {
                        ConnectionC2 = false;
                    }
                    else
                    {
                        // 기타 소켓 예외 발생
                    }
                }
            }
        }
    }
}
