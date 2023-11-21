using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using TCP_Service.Model;
using TCP_Service.View;

namespace TCP_Service.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // 생성자
        public MainViewModel()
        {
            // 메뉴
            OpenContextMenuCommand = new ViewModelCommand(ExecuteOpenContextMenuCommand);
            MenuCommand1 = new ViewModelCommand(ExecuteMenuCommand1);
            MenuCommand2 = new ViewModelCommand(ExecuteMenuCommand2);
            SubMenuCommand1 = new ViewModelCommand(ExecuteSubMenuCommand1);
            SubMenuCommand2 = new ViewModelCommand(ExecuteSubMenuCommand2);

            // TCP 통신 관련
            SendMsgCommand = new ViewModelCommand(ExecuteSendMsgCommand);
            GoSecondViewCommand = new ViewModelCommand(ExecuteGoSecondViewCommand);
            TCPService.Instance.MessageReceived += OnMessageReceived;           // 구독

        }

        public Visibility Menu2Visibility
        {
            get
            {
                if (MainModel.Instance.Num == 1)
                {
                    return Visibility.Visible;                  // 보임
                }
                else
                {
                    return Visibility.Collapsed;            // 안보임
                }
            }
        }

        public ICommand OpenContextMenuCommand { get; set; }
        public ICommand MenuCommand1 { get; set; }
        public ICommand MenuCommand2 { get; set; }
        public ICommand SubMenuCommand1 { get; set; }
        public ICommand SubMenuCommand2 { get; set; }

        private void ExecuteOpenContextMenuCommand(object obj)
        {
            if (obj is Button button && button.ContextMenu != null)
            {
                var contextMenu = button.ContextMenu;

                contextMenu.PlacementTarget = button;
                contextMenu.Placement = PlacementMode.Top;
                contextMenu.IsOpen = true;

            }
        }

        private void ExecuteMenuCommand1(object obj)
        {
            MessageBox.Show("메뉴1");
        }

        private void ExecuteMenuCommand2(object obj)
        {
            MessageBox.Show("메뉴2");
        }

        private void ExecuteSubMenuCommand1(object obj)
        {
            MessageBox.Show("서브 메뉴1");
        }

        private void ExecuteSubMenuCommand2(object obj)
        {
            MessageBox.Show("서브 메뉴2");
        }


        // TCP통신 관련
        private string m_text_box_msg;

        public ICommand SendMsgCommand { get; set; }
        public ICommand GoSecondViewCommand { get; set; }
        public string TextBoxMsg
        {
            get => m_text_box_msg;
            set
            {
                m_text_box_msg = value;
                OnPropertyChanged(nameof(TextBoxMsg));
            }
        }
        public string UIMsg
        {
            get => MainModel.Instance.UIMsg;
            set
            {
                MainModel.Instance.UIMsg = value;
                OnPropertyChanged(nameof(UIMsg));
            }
        }

        private void OnMessageReceived(object sender, string msg)
        {
            UIMsg = msg;
        }

        private async void ExecuteSendMsgCommand(object obj)
        {
            await TCPService.Instance.SendToServer(TextBoxMsg);
            TextBoxMsg = ""; // 메시지 전송 후 텍스트 박스 비우기
        }

        // 두번째 창을 열고 현재 창을 닫는다
        private void ExecuteGoSecondViewCommand(object obj)
        {
            SecondView second_view = new SecondView();
            second_view.Show();

            if (obj is Window window)
            {
                window.Close();
            }
        }
    }
}
