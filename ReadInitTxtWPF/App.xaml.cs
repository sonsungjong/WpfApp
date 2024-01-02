using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ReadInitTxtWPF.Model;
using ReadInitTxtWPF.View;
using ReadInitTxtWPF.ViewModel;

namespace ReadInitTxtWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            LangModel.Instance.langFile(1);
            var view = new LangView();
            view.Show();
            
        }

    }
}
