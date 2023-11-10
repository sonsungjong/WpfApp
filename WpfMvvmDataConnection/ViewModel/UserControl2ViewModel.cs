using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmDataConnection.ViewModel
{
    public class UserControl2ViewModel : ViewModelBase
    {
        // 다른 ViewModel에 구독시킬 핸들러
        public event EventHandler<int> UserControl2IntPropChanged;
        public event EventHandler<string> UserControl2StringPropChanged;

        public ICommand User2Btn1Command { get; set; }
        public ICommand User2Btn2Command { get; set; }
        public ICommand User2Btn3Command { get; set; }

        public UserControl2ViewModel()
        {
            User2Btn1Command = new ViewModelCommand(ExecuteBtn1);
            User2Btn2Command = new ViewModelCommand(ExecuteBtn2);
            User2Btn3Command = new ViewModelCommand(ExecuteBtn3);
        }

        private void ExecuteBtn1(object obj)
        {
            UserControl2IntPropChanged?.Invoke(this, 10000);
            UserControl2StringPropChanged?.Invoke(this, "유저2 - 버튼1");
        }

        private void ExecuteBtn2(object obj)
        {
            UserControl2IntPropChanged?.Invoke(this, 20000);
        }

        private void ExecuteBtn3(object obj)
        {
            UserControl2IntPropChanged?.Invoke(this, 30000);
        }

    }
}
