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

namespace WPF_CS
{
    /// <summary>
    /// Interaction logic for margin_ctls.xaml
    /// </summary>
    public partial class margin_ctls : Window
    {
        public margin_ctls()
        {
            InitializeComponent();
        }

        private void Grid_Button_Click(object sender, RoutedEventArgs e)
        {
            //First_cs_window.Title = "hello world!";                 // x:Name
            xName_Button.Content = "Hello Button";
            xName_Label.Content = "wow x:Name";
            xName_TextBox.Text = "x:Name Text";
            this.Title = "this Title";
            this.Background = System.Windows.Media.Brushes.Brown;
            this.xName_TextBox.Background = System.Windows.Media.Brushes.YellowGreen;
            this.xName_Button.Foreground = System.Windows.Media.Brushes.Red;
            this.main_grid.Visibility = Visibility.Hidden;
            //this.main_grid.Visibility = Visibility.Visible;
            //this.Visibility = Visibility.Hidden;

            System.Windows.MessageBox.Show("content","title");
        }
    }
}
