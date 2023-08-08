using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UITCC.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        // 멤버변수
        private readonly Action<object> m_execute;
        private readonly Func<object, bool> m_can_execute;

        // 생성자
        public ViewModelCommand(Action<object> execute)
        {
            m_execute = execute;
            m_can_execute = null;
        }

        public ViewModelCommand(Action<object> execute, Func<object, bool> can_execute)
        {
            m_execute = execute;
            m_can_execute = can_execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return m_can_execute == null ? true : m_can_execute(parameter);
        }

        public void Execute(object parameter)
        {
            m_execute(parameter);
        }
    }
}
