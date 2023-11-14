using MVVM_TCP.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_TCP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var mainView = new MainView();
            mainView.Show();
            mainView.IsVisibleChanged += (s, ev) =>
            {
                if (mainView.IsVisible == false && mainView.IsLoaded)
                {
                    var secondView = new SecondWindowView();
                    secondView.Show();
                    mainView.Close();
                }
            };
        }
    }
}
