using MVVM_TCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await ConnectToServer(m_host, m_port);
        }

        public ICommand SendMessageCommand { get; set; }
        private async Task ExecuteSendMessageCommand()
        {
            await SendToServer(TextBoxMsg);             // 프로퍼티를 전송
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

        public async Task ConnectToServer(string a_host, int a_port)
        {
            await TCPManager.Instance.ConnectAsync(a_host, a_port);
        }

        public async Task SendToServer(string a_msg)
        {
            await TCPManager.Instance.SendAsync(a_msg);
        }
        
        public async Task RecvFromServer()
        {
            string recv_msg = await TCPManager.Instance.ReceiveAsync();
            UIMsg = recv_msg;
        }

    }
}
