using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NS_UDPServer
{
    public class UDPServer
    {
        public static void Main()
        {
            int port = 12345;
            IPAddress localAddress = IPAddress.Any;

            // UDP 클라이언트 설정 및 바인딩
            UdpClient udpClient = new UdpClient(port);
            Console.WriteLine($"서버가 {localAddress}:{port}에서 수신 대기 중");

            // 클라이언트로부터 메시지를 수신하기 위해 무한 루프
            while (true)
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, port);
                byte[] data = udpClient.Receive(ref remoteEP);
                string msg = Encoding.Unicode.GetString(data);
                Console.WriteLine($"수신: {msg} (from {remoteEP})");

                // 필요한 경우 응답을 클라이언트에게 보낼 수 있습니다.
                byte[] response = Encoding.Unicode.GetBytes("메시지를 받았습니다!");
                udpClient.Send(response, response.Length, remoteEP);
            }
        }
    }
}