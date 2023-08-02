using System;
using System.Windows.Input;

namespace ModernDashboard
{
    /*
     RelayCommand allows you to inject the command's logic via delegates passed into its constructor.
    This method enables ViewModel classes to implement commands in a concise manner.

    RelayCommand를 사용하면 생성자에 전달된 delegates를 통해 명령의 논리를 주입할 수 있습니다.
     이 방법을 사용하면 ViewModel 클래스가 간결한 방식으로 명령을 구현할 수 있습니다.
     */
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
            canExecute = null;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /*
         CanExecuteChanged delegates the event subscription to the CommandManager.RequerySuggested event.
        This ensures that the WPF commanding infrastructure asks all RelayCommand objects if they can execute whenever it asks the built-in commands.
        CanExecuteChanged는 이벤트 구독을 CommandManager.RequerySuggested 이벤트에 위임합니다.
         이렇게 하면 WPF 명령 인프라가 기본 제공 명령을 요청할 때마다 실행할 수 있는지 여부를 모든 RelayCommand 개체에 묻습니다.
         */
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
