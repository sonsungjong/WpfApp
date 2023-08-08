using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UITCC.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        // 멤버변수
        public string m_user_id;
        public string m_user_pw;
        public string m_err_msg;
        public bool m_visible = true;

        // Properties
        public string UserId
        {
            get
            {
                return m_user_id;
            }
            set
            {
                m_user_id = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public string UserPw
        {
            get
            {
                return m_user_pw;
            }
            set { 
                m_user_pw = value;
                OnPropertyChanged(nameof(UserPw));
            }
        }

        public string ErrMsg
        {
            get
            {
                return m_err_msg;
            }
            set
            {
                m_err_msg = value;
                OnPropertyChanged(nameof(ErrMsg));
            }
        }

        public bool Visible
        {
            get
            {
                return m_visible;
            }
            set
            {
                m_visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        // Command
        public ICommand LoginCommand { get; }
        
        // 생성자
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool valid_data;

            // 3글자 이상, 비어있지 않게
            if (string.IsNullOrWhiteSpace(UserId) || UserId.Length < 3 || UserPw == null || UserPw.Length < 3)
            {
                valid_data = false;
            }
            else
            {
                valid_data = true;          // 타당한 계정정보
            }

            return valid_data;          // bool 결과 리턴
        }

        private void ExecuteLoginCommand(object obj)
        {
            //var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            //if (isValidUser)
            //{
            //    Thread.CurrentPrincipal = new GenericPrincipal(
            //        new GenericIdentity(Username), null);
            //    IsViewVisible = false;
            //}
            //else
            //{
            //    ErrorMessage = "* Invalid username or password";
            //}
        }
    }
}
