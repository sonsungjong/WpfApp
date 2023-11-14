using MVVM_TCP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_TCP.View
{
    /// <summary>
    /// Interaction logic for SecondWindowView.xaml
    /// </summary>
    public partial class SecondWindowView : Window
    {
        public SecondWindowView()
        {
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            var new_window = new MainView();

            new_window.Show();

            this.Close();
        }
    }
}
