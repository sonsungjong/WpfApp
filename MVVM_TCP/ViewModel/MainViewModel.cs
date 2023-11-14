using MVVM_TCP.Model;
using MVVM_TCP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MVVM_TCP.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private string m_ui_msg;
        private string m_textbox_msg;
        private string m_host = "localhost";
        private int m_port = 8888;

        public MainViewModel()
        {
            ConnectCommand = new ViewModelCommand(async (param) => await ExecuteConnectCommand());
            SendMessageCommand = new ViewModelCommand(async (param) => await ExecuteSendMessageCommand());


        }

        public ICommand ConnectCommand { get; set; }
        private async Task ExecuteConnectCommand()
        {
            await ConnectToServer(m_host, m_port);              // TCP 서버에 연결 (싱글턴이라 한번만)
        }

        public ICommand SendMessageCommand { get; set; }
        private async Task ExecuteSendMessageCommand()
        {
            await SendToServer(TextBoxMsg);             // TCP로 프로퍼티를 전송
        }




        public string UIMsg
        {
            get { return m_ui_msg; }
            set
            {
                m_ui_msg = value;
                OnPropertyChanged(nameof(UIMsg));
            }
        }

        public string TextBoxMsg
        {
            get => m_textbox_msg;
            set
            {
                m_textbox_msg = value;
                OnPropertyChanged(nameof(TextBoxMsg));
            }
        }

        // ============================== ViewModel에서 TCP 고정코드 ===================================
        public async Task ConnectToServer(string a_host, int a_port)
        {
            await TCPManager.Instance.ConnectAsync(a_host, a_port);


            RecvFromServer();
        }

        public async Task SendToServer(string a_msg)
        {
            await TCPManager.Instance.SendAsync(a_msg);
        }
        
        public void RecvFromServer()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        string recv_msg = await TCPManager.Instance.ReceiveAsync();
                        UIMsg = recv_msg;
                    }
                    catch(Exception ex)
                    {
                        UIMsg = ex.ToString();
                        break;
                    }
                }
            });
        }


    }
}
