using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_TCP.Model
{
    internal class TCPManager
    {
        private static readonly TCPManager m_instance = new TCPManager();
        private TcpClient m_tcp_client;
        private NetworkStream m_stream;

        // 싱글턴 인스턴스 접근을 위한 프로퍼티
        public static TCPManager Instance
        {
            get { return m_instance; }
        }

        // 생성자를 private으로 생성하여 싱글턴패턴
        private TCPManager()
        {
            m_tcp_client = new TcpClient();
        }

        public async Task ConnectAsync(string a_host, int a_port)
        {
            await m_tcp_client.ConnectAsync(a_host, a_port);
            m_stream = m_tcp_client.GetStream();
        }

        public async Task<string> ReceiveAsync()
        {
            const int buffer_size = 50000;
            byte[] buffer = new byte[buffer_size];
            StringBuilder recv_msg = new StringBuilder();
            int bytes_read;

            do
            {
                bytes_read = await m_stream.ReadAsync(buffer, 0, buffer.Length);
                recv_msg.Append(Encoding.Unicode.GetString(buffer, 0, bytes_read));
            } while (bytes_read > 0); // 더 이상 읽을 데이터가 없을 때 루프를 종료

            return recv_msg.ToString();
        }

        public async Task SendAsync(string a_msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(a_msg);
            await m_stream.WriteAsync(data, 0, data.Length);
        }

        public void ParseHeaderAfterRecv()
        {

        }

        public void AddHeaderBeforeSend(string a_msg)
        {

        }

    }
}
