using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TCP_Service.Model
{
    public class TCPService
    {
        private TcpClient m_tcp_client;
        private NetworkStream m_stream;
        public event EventHandler<string> MessageReceived;              // 각 ViewModel에서 구독하여 메시지 수신

        public async Task ConnectToServer(string a_host, int a_port)
        {
            try
            {
                // 서버에 연결
                await m_tcp_client.ConnectAsync(a_host, a_port);
                m_stream = m_tcp_client.GetStream();

                // 비동기로 메시지 수신 시작
                await RecvMsg();
            }
            catch (SocketException)
            {
                MessageBox.Show("서버에 연결할 수 없습니다.", "연결 오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"연결 중 오류 발생: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // 각 ViewModel에서 재정의하여 메시지 수신
        public virtual void OnMessageReceived(string msg)
        {
            MessageReceived?.Invoke(this, msg);
        }

        public async Task RecvMsg()
        {
            byte[] buffer = new byte[16384];
            int bytes_read = 0;

            try
            {
                while ((bytes_read = await m_stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    // 수신된 바이트를 문자열로 변환
                    string receivedMessage = Encoding.Default.GetString(buffer, 0, bytes_read);

                    // 헤더를 나눠서 분기문을 태우고 수신받을 메서드 정의
                    OnMessageReceived(receivedMessage);
                }
            }
            catch(Exception ex)
            {
                // 예외 처리
                OnMessageReceived($"수신 중 오류 발생: {ex.Message}");
                MessageBox.Show("메시지 수신 중 오류 발생");
            }
        }


        public async Task SendToServer(string a_msg)
        {
            if(a_msg != null)
            {
                byte[] data = Encoding.Default.GetBytes(a_msg);
                await m_stream.WriteAsync(data, 0, data.Length);
            }
        }

        public void ParseHeaderAfterRecv()
        {

        }

        public void AddHeaderBeforeSend(string a_msg)
        {

        }

        // 서버와 연결 해제
        public void DisConnectServer()
        {
            m_stream?.Close();
            m_tcp_client?.Close();
        }


        // 싱글턴패턴 적용
        private static readonly TCPService m_instance = new TCPService();
        private TCPService()
        {
            m_tcp_client = new TcpClient();
        }
        public static TCPService Instance
        {
            get => m_instance;
        }

    }
}
