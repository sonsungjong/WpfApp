using MVVM_TCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;

namespace MVVM_TCP.ViewModel
{
    public class SecondWindowViewModel : ViewModelBase
    {
        private string m_second_ui_msg;
        private string m_second_textbox_msg;

        public SecondWindowViewModel()
        {
            // 서버로 보내기 버튼
            Second_SendMessageCommand = new ViewModelCommand(async (param) => await ExecuteSecondSendBtnCommand());
        }

        public ICommand Second_SendMessageCommand { get; set; }
        private async Task ExecuteSecondSendBtnCommand()
        {
            await SendToServer(Second_TextBoxMsg);             // TCP로 프로퍼티를 전송
        }

        public string Second_UIMsg
        {
            get => m_second_ui_msg;
            set
            {
                m_second_ui_msg = value;
                OnPropertyChanged(nameof(Second_UIMsg));
            }
        }

        public string Second_TextBoxMsg
        {
            get => m_second_textbox_msg;
            set
            {
                m_second_textbox_msg = value;
                OnPropertyChanged(nameof(Second_TextBoxMsg));
            }
        }

        // ============================== ViewModel에서 TCP 고정코드 ===================================

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
                        Second_UIMsg = recv_msg;
                    }
                    catch (Exception ex)
                    {
                        Second_UIMsg = ex.ToString();
                        break;
                    }
                }
            });
        }
    }
}
