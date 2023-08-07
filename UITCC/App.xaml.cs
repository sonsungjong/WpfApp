using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UITCC
{
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            /*
            var login_view = new LoginView();
            login_view.Show();
            login_view.IsVisibleChanged += (s, ev) =>
            {
                if(login_view.IsVisible == false && login_view.IsLoaded)
                {
                    var select_mode_view = new select_mode_view();
                    select_mode_view.Show();
                    login_view.Close();
                }
            };
            */
        }
    }
}
