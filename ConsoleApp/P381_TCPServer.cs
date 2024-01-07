using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp
{
    internal class P381_TCPServer
    {
        public static string m_host = "localhost";
        public static int m_port = 10000;               // 포트번호
        public static void Main381()
        {
            IPHostEntry ipHostEntry = Dns.GetHostEntry(m_host);             // IP 대입
            TcpListener tcpListener = new TcpListener(ipHostEntry.AddressList[0], m_port);              // PORT 대입

            tcpListener.Start();

            Console.WriteLine("대기합니다.");

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();            // 접속을 accept해서 받아들인다
                StreamWriter streamWriter = new StreamWriter(tcpClient.GetStream());
                streamWriter.WriteLine("이쪽은 서버입니다.");           // 문자열
                streamWriter.Flush();

                streamWriter.Close();
                tcpClient.Close();              // 접속을 해제시킨다
                break;
            }
        }
    }
}
