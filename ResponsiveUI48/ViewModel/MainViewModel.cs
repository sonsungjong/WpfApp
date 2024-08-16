using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ResponsiveUI48.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // Constructor
        public MainViewModel()
        {
            IsPanelVisible = false;
        }

        public void CloseApp(object obj)
        {
            MainWindow win = obj as MainWindow;
            win.Close();
        }

        private ICommand m_closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if(m_closeCommand == null)
                {
                    m_closeCommand = new ViewModelCommand(p => CloseApp(p));
                }
                return m_closeCommand;
            }
        }

        public void MaxApp(object obj)
        {
            MainWindow win = obj as MainWindow;
            if(win.WindowState == WindowState.Normal)
            {
                win.WindowState = WindowState.Maximized;
            }
            else if(win.WindowState == WindowState.Maximized)
            {
                win.WindowState = WindowState.Normal;
            }
        }

        private ICommand m_maxCommand;
        public ICommand MaxAppCommand
        {
            get
            {
                if(m_maxCommand == null)
                {
                    m_maxCommand = new ViewModelCommand(p => MaxApp(p));
                }
                return m_maxCommand;
            }
        }

        public void CloseMenu()
        {
            IsPanelVisible = false;
        }

        public void ShowMenu()
        {
            IsPanelVisible = true;
        }

        private ICommand m_showMenuCommand;
        public ICommand ShowMenuCommand
        {
            get
            {
                if(m_showMenuCommand == null)
                {
                    m_showMenuCommand = new ViewModelCommand(p => ShowMenu());
                }
                return m_showMenuCommand;
            }
        }

        private ICommand m_closeMenuCommand;
        public ICommand CloseMenuCommand
        {
            get
            {
                if(m_closeMenuCommand == null)
                {
                    m_closeMenuCommand = new ViewModelCommand(p => CloseMenu());
                }
                return m_closeMenuCommand;
            }
        }

        private bool m_isPanelVisible;
        public bool IsPanelVisible
        {
            get => m_isPanelVisible;
            set
            {
                m_isPanelVisible = value;
                OnPropertyChanged("IsPanelVisible");
            }
        }
    }
}
