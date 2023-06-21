using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TacticMVVM.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _Excute { get; set; }
        private Predicate<object> _CanExcute { get; set; }

        public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod)
        {
            _Excute = ExcuteMethod;
            _CanExcute = CanExcuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            // parameter == 커맨드
            return _CanExcute(parameter);
        }

        public void Execute(object parameter)
        {
            // parameter == 커맨드
            _Excute(parameter);
        }
    }
}
