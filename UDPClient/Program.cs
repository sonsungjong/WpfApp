using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NS_UDPClient
{
    public class UDPClient
    {
        public static void Main()
        {
            int port = 12345;
            string serverAddress = "172.16.1.157"; // 서버의 IP 주소

            UdpClient udpClient = new UdpClient();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(serverAddress), port);

            Console.WriteLine($"서버 {serverAddress}:{port}에 메시지를 보내려면 메시지를 입력하세요.");
            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                udpClient.Send(data, data.Length, serverEP);

                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, port);
                byte[] response = udpClient.Receive(ref remoteEP);
                string responseMessage = Encoding.Unicode.GetString(response);
                Console.WriteLine($"서버 응답: {responseMessage}");
            }
        }
    }
}
