using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TCP_Service.Model;
using TCP_Service.View;

namespace TCP_Service.ViewModel
{
    public class SecondViewModel : ViewModelBase
    {
        public SecondViewModel()
        {
            GoMainViewCommand = new ViewModelCommand(ExecuteGoMainViewCommand);
            Second_SendMsgCommand = new ViewModelCommand(ExecuteSecond_SendMsgCommand);

            TCPService.Instance.MessageReceived += OnSecondMessageReceived;           // 구독
        }

        private string m_second_text_box_msg;
        //private string m_second_ui_msg;

        public ICommand Second_SendMsgCommand { get; set; }
        public ICommand GoMainViewCommand { get; set; }

        public string Second_TextBoxMsg
        {
            get => m_second_text_box_msg;
            set
            {
                m_second_text_box_msg = value;
                OnPropertyChanged(nameof(Second_TextBoxMsg));
            }
        }

        public string Second_UIMsg
        {
            get => MainModel.Instance.UIMsg;
            set
            {
                MainModel.Instance.UIMsg = value;
                OnPropertyChanged(nameof(Second_UIMsg));
            }
        }

        private async void ExecuteSecond_SendMsgCommand(object obj)
        {
            await TCPService.Instance.SendToServer(Second_TextBoxMsg);
            Second_TextBoxMsg = ""; // 메시지 전송 후 텍스트 박스 비우기
        }

        // MainView를 띄우고 현재창 닫기
        private void ExecuteGoMainViewCommand(object obj)
        {
            MainView main_view = new MainView();
            main_view.Show();

            if(obj is Window window)
            {
                window.Close();
            }
        }

        private void OnSecondMessageReceived(object sender, string msg)
        {
            Second_UIMsg = msg;
        }
    }
}
