using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;             // 추가

namespace WPF_RJ.ViewModel
{
    public class ViewModelCommand : ICommand                // I커맨드 상속
    {
        // 멤버 변수
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        // 이벤트
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }
        
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
