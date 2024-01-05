using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMvvmDataConnection.Model;
using WpfMvvmDataConnection.View;

namespace WpfMvvmDataConnection.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private MainModel m_model;
        private ViewModelBase m_current_user_control;

        // 모달리스창 관리
        private SecondWindow m_secondWindow;
        private SecondWindowViewModel m_secondWindowVM;

        public MainViewModel()
        {
            m_model = new MainModel();

            ShowUserControl1 = new ViewModelCommand(ExecuteShowUserControl1);
            ShowUserControl2 = new ViewModelCommand(ExecuteShowUserControl2);
            MainButtonCommand = new ViewModelCommand(ExecuteMainButtonClicked);
            ShowSecondWindow = new ViewModelCommand(ExecuteShowSecondWindow);

            m_model.MyInt = 123123;
            m_model.MyString = "안녕하세요";

            ExecuteShowUserControl1(null);
        }

        private void ExecuteMainButtonClicked(object obj)
        {
            MessageBox.Show("메인 버튼이 클릭됨");
            MyInt = 0;
            MyString = "";

            if(m_secondWindowVM != null)
            {
                m_secondWindowVM.TextBlockString = "메인 버튼이 클릭됨";
            }
        }

        private void ExecuteShowSecondWindow(object obj)
        {
            if(m_secondWindow == null || !m_secondWindow.IsLoaded)                  // 중복실행 방지
            {
                m_secondWindowVM = new SecondWindowViewModel();
                m_secondWindowVM.m_Send50 += SecondWindowVM_Send50;
                m_secondWindowVM.m_SendString += SecondWindowVM_SendString;
                m_secondWindow = new SecondWindow
                {
                    DataContext = m_secondWindowVM
                };
                m_secondWindow.Show();                                      // 모달리스로 전시
            }
        }

        private void SecondWindowVM_Send50(object sender, EventArgs e)
        {
            if(sender is int newValue)
            {
                MyInt = newValue;
            }
        }

        private void SecondWindowVM_SendString(object sender, EventArgs e)
        {
            if(sender is string newValue)
            {
                MyString = newValue;
            }
        }

        private void ExecuteShowUserControl1(object obj)
        {
            var userControl1VM = new UserControl1ViewModel();
            userControl1VM.PropertyChanged += UserControl1VM_PropertyChanged;
            userControl1VM.IntPropertyChanged += UserControl1VM_IntPropertyChanged;
            userControl1VM.SendSecondWindow33333 += UserControl1VM_Send33333;
            CurrentUserControl = userControl1VM;
        }

        private void ExecuteShowUserControl2(object obj)
        {
            var userControl2VM = new UserControl2ViewModel();
            userControl2VM.UserControl2IntPropChanged += UserControl2VM_IntPropChanged;                     // 구독
            userControl2VM.UserControl2StringPropChanged += UserControl2VM_StringPropChanged;           // 구독
            CurrentUserControl = userControl2VM;
        }

        private void UserControl1VM_IntPropertyChanged(object sender, EventArgs e)
        {
            if(sender is int newValue)
            {
                MyInt = newValue;
                //MyInt += newValue;
            }
        }

        private void UserControl1VM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(UserControl1ViewModel.StringProperty))
            {
                var userControl1VM = sender as UserControl1ViewModel;
                if (userControl1VM != null)
                {
                    MyString = userControl1VM.StringProperty;
                }
            }
        }

        private void UserControl2VM_IntPropChanged(object sender, EventArgs e)
        {
            if(sender is int newValue)
            {
                MyInt = newValue;                   // MyInt 프로퍼티 업데이트
            }
        }

        private void UserControl2VM_StringPropChanged(object sender, EventArgs e)
        {
            if(sender is string newValue)
            {
                MyString = newValue;                 // MyString 프로퍼티 업데이트
            }
        }

        public ICommand ShowUserControl1 { get; set; }
        public ICommand ShowUserControl2 { get; set; }
        public ICommand MainButtonCommand { get; set; }
        public ICommand ShowSecondWindow { get; set; }

        public string MyString
        {
            get => m_model.MyString;
            set
            {
                if(m_model.MyString != value)
                {
                    m_model.MyString = value;
                    OnPropertyChanged(nameof(MyString));
                }
            }
        }

        public int MyInt
        {
            get => m_model.MyInt;
            set
            {
                if(m_model.MyInt != value)
                {
                    m_model.MyInt = value;
                    OnPropertyChanged(nameof(MyInt));
                }
            }
        }

        public ViewModelBase CurrentUserControl
        {
            get => m_current_user_control;
            set
            {
                m_current_user_control = value;
                OnPropertyChanged(nameof(CurrentUserControl));
            }
        }

        // MainViewModel(UserControl1ViewModel) -> MainViewModel -> SecondWindowViewModel
        private void UserControl1VM_Send33333(object sender, EventArgs e)
        {
            if (m_secondWindowVM != null)
            {
                if(sender is int newValue)
                {
                    m_secondWindowVM.OnUpdateIntValue33333(newValue);
                }
            }
        }
    }
}
