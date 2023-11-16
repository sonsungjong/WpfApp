using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TCP_Service.Model;
using TCP_Service.View;

namespace TCP_Service
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            // TCP 비동기 연결을 백그라운드 태스크로 실행
            Task.Run(async () =>
            {
                await TCPService.Instance.ConnectToServer("localhost", 8888);
            });

            MainView main_view = new MainView();
            main_view.Show();
        }
    }
}
