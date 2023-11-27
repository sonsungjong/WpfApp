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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace GMapNet48
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            gMapControl.MapProvider = GMapProviders.OpenStreetMap;
            gMapControl.MinZoom = 1;
            gMapControl.MaxZoom = 17;
            gMapControl.Zoom = 9;
            gMapControl.ShowCenter = false;
            gMapControl.DragButton = MouseButton.Left;              // 지도 드래그 이동
            //RectLatLng bounds = new RectLatLng(85, -180, 360, 170);
            //GoogleMapProvider.Instance.ApiKey = "AIzaSyCXJrDpszuNQfMEXKIifx5zYzhSq3Irpyg";        // (OpenStreetMap)



            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // 초기 위치
            gMapControl.Position = new PointLatLng(37.7749, -122.4194);


        }

    }
}
