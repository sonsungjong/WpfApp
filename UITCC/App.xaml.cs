using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UITCC.Model;
using UITCC.View;

namespace UITCC
{
    public partial class App : Application
    {

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var login_view = new LoginView();
            login_view.Show();
            login_view.IsVisibleChanged += (s, ev) =>
            {
                if (login_view.IsVisible == false && login_view.IsLoaded)
                {
                    var select_mode_view = new SelectModeView();
                    select_mode_view.Show();
                    login_view.Close();
                }
            };
        }

        // 앱 실행시
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 연결상태 체크
            ConnectionStatusModel.Instance.StartUDPServer();
        }
    }
}
