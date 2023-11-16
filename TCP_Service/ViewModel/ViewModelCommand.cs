using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TCP_Service.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        private readonly Action<object> m_execute;
        private readonly Func<object, bool> m_can_execute;

        public ViewModelCommand(Action<object> a_execute)
        {
            this.m_execute = a_execute;
            this.m_can_execute = null;
        }

        public ViewModelCommand(Action<object> a_execute, Func<object, bool> a_can_execute)
        {
            this.m_execute = a_execute;
            this.m_can_execute = a_can_execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object a_parameter)
        {
            return this.m_can_execute == null ? true : this.m_can_execute(a_parameter);
        }

        public void Execute(object a_parameter)
        {
            this.m_execute(a_parameter);
        }
    }
}
