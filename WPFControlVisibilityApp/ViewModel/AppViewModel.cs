using System.ComponentModel;
using System.Windows.Input;

namespace WPFControlVisibilityApp.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private bool _isPanelVisible;
        private ICommand _showPanelCommand;
        private ICommand _hidePanelCommand;

        // 생성자
        public AppViewModel()
        {
            // Set Default Panel Visibility
            _isPanelVisible = false;
        }

        // Panel Visibility Property
        public bool IsPanelVisible
        {
            get
            {
                return _isPanelVisible;
            }
            set
            {
                _isPanelVisible = value;
                OnPropertyChanged("IsPanelVisible");
            }
        }

        // Show Panel Method
        public void ShowPanel()
        {
            IsPanelVisible = true;
        }

        // Show Panel Command
        public ICommand ShowPanelCommand
        {
            get
            {
                if (_showPanelCommand == null)
                {
                    _showPanelCommand = new RelayCommand.Command.RelayCommand(p => ShowPanel());
                }
                return _showPanelCommand;
            }
        }

        // Hide Panel Mothod
        public void HidePanel()
        {
            IsPanelVisible = false;
        }

        // Hide Panel Command
        public ICommand HidePanelCommand
        {
            get
            {
                if(_hidePanelCommand == null)
                {
                    _hidePanelCommand = new RelayCommand.Command.RelayCommand(p => HidePanel());
                }
                return _hidePanelCommand;
            }
        }

        // 앱 창 닫은 메서드
        public void CloseApp(object obj)
        {
            MainWindow win = obj as MainWindow;
            win.Close();
        }

        // Close App Command
        private ICommand _closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if(_closeCommand == null)
                {
                    _closeCommand = new RelayCommand.Command.RelayCommand(p=> CloseApp(p));
                }
                return _closeCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
