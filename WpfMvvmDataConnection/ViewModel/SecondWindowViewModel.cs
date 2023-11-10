using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmDataConnection.ViewModel
{
    public class SecondWindowViewModel : ViewModelBase
    {
        private string m_text_box_string;                   // 에디트컨트롤 문자열 저장
        private string m_text_block_string;                     // 텍스트 문자열 저장
        private int m_int_value;                  // 텍스트 정수 저장
        public event EventHandler<int> m_Send50;
        public event EventHandler<string> m_SendString;

        // MainViewModel(UserControl1ViewModel) -> MainViewModel -> SecondWindowViewModel
        public event EventHandler<int> UpdateIntValue33333;

        public SecondWindowViewModel()
        {
            SendStringCommand = new ViewModelCommand(ExecuteSendStringCommand);
            SendIntCommand = new ViewModelCommand(ExecuteSendIntCommand);

            m_text_box_string = "";
            m_text_block_string = "MainView에서 전달받는 값을 전시";
            m_int_value = 3000;

            UpdateIntValue33333 += (sender, value) => IntValue = value;
        }

        public string TextBoxString
        {
            get => m_text_box_string;
            set
            {
                m_text_box_string = value;
                OnPropertyChanged(nameof(TextBoxString));
            }
        }

        public string TextBlockString
        {
            get => m_text_block_string;
            set
            {
                m_text_block_string = value;
                OnPropertyChanged(nameof(TextBlockString));
            }
        }

        public int IntValue
        {
            get => m_int_value;
            set
            {
                m_int_value = value;
                OnPropertyChanged(nameof(IntValue));
            }
        }

        // 에디트 컨트롤에 있는 문자열을 MainViewModel의 MyString에 전달
        public ICommand SendStringCommand { get; set; }

        // 50을 MainViewModel의 MyInt에 전달
        public ICommand SendIntCommand { get; set; }

        private void ExecuteSendStringCommand(object obj)
        {
            //MessageBox.Show(TextBoxString+"을 MainView의 MyString에 전달하자");
            m_SendString?.Invoke(this, TextBoxString);
            TextBlockString = TextBoxString + "을(를) 보냈다";
        }

        private void ExecuteSendIntCommand(object obj)
        {
            //MessageBox.Show("MainView의 MyInt에 50을 전달하자");
            m_Send50?.Invoke(this, 50);
            TextBlockString = "50을 보냈다";
        }

        // MainViewModel(UserControl1ViewModel) -> MainViewModel -> SecondWindowViewModel
        public void OnUpdateIntValue33333(int value)
        {
            UpdateIntValue33333?.Invoke(this, value);
        }
    }
}
