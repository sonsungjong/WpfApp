using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace UITCC.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        // 멤버변수
        public string m_user_id;
        public string m_user_pw;
        public string m_err_msg;
        public bool m_visible = true;
        private string m_current_time;
        private DispatcherTimer m_timer;

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

        public string CurrentTime
        {
            get { return m_current_time; }
            set
            {
                m_current_time = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        // Command
        public ICommand LoginCommand { get; set; }
        
        // 생성자
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);

            m_timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            m_timer.Tick += Timer_Tick;
            m_timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(UserPw);
        }

        private void ExecuteLoginCommand(object obj)
        {
            // 데이터베이스(x64)의 사용자와 일치하면 로그인 화면을 비활성화 시킨다
            string db_path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sungjong.son\Documents\test.accdb;";

            using (OleDbConnection db_conn = new OleDbConnection(db_path))
            {
                db_conn.Open();
                string select_all_user_query = "SELECT * FROM [user]";
                using (OleDbCommand db_command = new OleDbCommand(select_all_user_query, db_conn))
                {
                    bool result = false;
                    // OleDBDataReader를 사용하여 쿼리 결과를 얻는다
                    using (OleDbDataReader reader = db_command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if(reader.GetString(0) == UserId && reader.GetString(1) == UserPw)
                            {
                                result = true;
                                break;
                            }
                        }
                    }

                    if (result == true)
                    {
                        // 일치하는 사용자 찾음
                        Visible = false;
                    }
                    else
                    {
                        // 일치하는 사용자 없음
                        ErrMsg = "Invalid user ID or password!";
                    }
                }
            }
        }
    }
}
