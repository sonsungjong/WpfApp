using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_RJ.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {

        public CustomerView()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.CanUserSort = false;
            e.Column.CanUserResize = false;

            DataGridTextColumn textColumn = e.Column as DataGridTextColumn;
            if (textColumn != null)
            {
                textColumn.ElementStyle = new Style(typeof(TextBlock))
                {
                    Setters = {
                new Setter(TextBlock.ForegroundProperty, Brushes.White),
                new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center),
                new Setter(TextBlock.BackgroundProperty, Brushes.Gold)
            }
                };
            }
        }
    }
}
