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
using WPF_RJ.ViewModel;

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

            this.DataContextChanged += (s, e) =>
            {
                BindHeaderUpdate();
            };
            // 혹시 DataContext 변경이 안 일어난다면, 아래 한 줄 추가
            BindHeaderUpdate();
        }

        private void BindHeaderUpdate()
        {
            if (this.DataContext is CustomerViewModel vm)
            {
                // 최초 헤더값 동기화
                dataGrid.Columns[0].Header = vm.HeaderNo;
                dataGrid.Columns[1].Header = vm.HeaderName;
                dataGrid.Columns[2].Header = vm.HeaderInfo;

                // PropertyChanged 구독 (중복 구독 방지하려면 WeakEventManager 등 활용)
                vm.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(vm.HeaderNo))
                        dataGrid.Columns[0].Header = vm.HeaderNo;
                    else if (e.PropertyName == nameof(vm.HeaderName))
                        dataGrid.Columns[1].Header = vm.HeaderName;
                    else if (e.PropertyName == nameof(vm.HeaderInfo))
                        dataGrid.Columns[2].Header = vm.HeaderInfo;
                };
            }
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
