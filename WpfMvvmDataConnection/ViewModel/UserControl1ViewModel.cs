using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmDataConnection.ViewModel
{
    public class UserControl1ViewModel : ViewModelBase
    {
        public event EventHandler IntPropertyChanged;
        public event EventHandler SendSecondWindow33333;
        private string m_str;
        private int m_int;

        public UserControl1ViewModel()
        {
            IntButtonCommand = new ViewModelCommand(ExecuteIntButtonCommand);
            SendSecoundWindowCommand = new ViewModelCommand(ExecuteSendSecondWindowCommand);
        }

        private void ExecuteIntButtonCommand(object obj)
        {
            IntPropertyChanged?.Invoke(IntProperty, EventArgs.Empty);
        }

        private void ExecuteSendSecondWindowCommand(object obj)
        {
            SendSecondWindow33333?.Invoke(33333, EventArgs.Empty);
        }

        public ICommand IntButtonCommand { get; set; }
        public ICommand SendSecoundWindowCommand { get; set; }

        public string StringProperty
        {
            get => m_str;
            set
            {
                m_str = value;
                OnPropertyChanged(nameof(StringProperty));
            }
        }

        public int IntProperty
        {
            get => m_int;
            set
            {
                m_int = value;
                OnPropertyChanged(nameof(IntProperty));
            }
        }


    }
}
