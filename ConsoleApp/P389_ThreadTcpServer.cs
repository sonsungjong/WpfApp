using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApp
{
    internal class P389_ThreadTcpServer
    {
        public static string m_host = "localhost";
        public static int m_port = 10001;
        public static void Main389()
        {
            IPHostEntry ipHostEntry = Dns.GetHostEntry(m_host);
            TcpListener tcpListener = new TcpListener(ipHostEntry.AddressList[0], m_port);
            tcpListener.Start();

            Console.WriteLine("대기합니다.");
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                Console.WriteLine("어서오세요.");

                Client client = new Client(tcpClient);
                Thread th = new Thread(client.run);
                th.Start();
            }
        }
    }

    class Client
    {
        private TcpClient m_tcpClient;
        public Client(TcpClient a_tcpClient)
        {
            m_tcpClient = a_tcpClient;
        }

        public void run()
        {
            StreamWriter streamWriter = new StreamWriter(m_tcpClient.GetStream());
            StreamReader streamReader = new StreamReader(m_tcpClient.GetStream());

            while (true)
            {
                try
                {
                    String str = streamReader.ReadLine();
                    streamWriter.WriteLine("서버:『" + str + "』입니다.");
                    streamWriter.Flush();
                }
                catch
                {
                    streamReader.Close();
                    streamWriter.Close();
                    m_tcpClient.Close();
                    break;
                }
            }
        }
    }
}
