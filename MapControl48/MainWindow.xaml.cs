using Microsoft.Maps.MapControl.WPF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;

namespace MapControl48
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

            // 지도의 중심 위치 설정
            Location center = new Location(47.606209, -122.332071);
            map.Center = center;
            map.ZoomLevel = 10;

            // 마커 추가
            Pushpin pin = new Pushpin();
            pin.Location = center;
            map.Children.Add(pin);
        }
    }
}
