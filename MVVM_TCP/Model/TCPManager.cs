using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_TCP.Model
{
    public class TCPManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TCPManager()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                // 관리 리소스 정리
                m_stream?.Dispose();
            }

            // 비관리 리소스 정리
            m_tcp_client?.Close();
            m_tcp_client?.Dispose();
        }

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
            byte[] buffer = new byte[16384];
            StringBuilder recv_msg = new StringBuilder();
            int bytes_read = 0;

            bytes_read = await m_stream.ReadAsync(buffer, 0, buffer.Length);
            recv_msg.Append(Encoding.Default.GetString(buffer, 0, bytes_read));

            return recv_msg.ToString();
        }

        public async Task SendAsync(string a_msg)
        {
            byte[] data = Encoding.Default.GetBytes(a_msg);
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
