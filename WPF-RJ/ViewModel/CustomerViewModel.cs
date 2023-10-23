using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_RJ.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        public ICommand ImageButtonCommand { get; }

        public CustomerViewModel()
        {
            ImageButtonCommand = new ViewModelCommand(ExecuteImageButtonCommand);

        }

        private void ExecuteImageButtonCommand(object obj)
        {
            MessageBox.Show("hello");
        }
    }
}
