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
            gMapControl.MinZoom = 5;
            gMapControl.MaxZoom = 10;
            gMapControl.Zoom = 7;
            gMapControl.ShowCenter = false;
            gMapControl.DragButton = MouseButton.Left;              // 지도 드래그 이동
            //RectLatLng bounds = new RectLatLng(85, -180, 360, 170);
            //GoogleMapProvider.Instance.ApiKey = "AIzaSyCXJrDpszuNQfMEXKIifx5zYzhSq3Irpyg";        // (OpenStreetMap)
            gMapControl.MouseRightButtonDown += gMapControl_MouseRightButtonDown;


            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            // 초기 위치
            gMapControl.Position = new PointLatLng(24.5, 54.5);

        }
        private void gMapControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 마우스 위치를 지도 좌표로 변환
            var point = e.GetPosition(gMapControl);
            var latLng = gMapControl.FromLocalToLatLng((int)point.X, (int)point.Y);

            // 메시지 박스로 위도와 경도 표시
            MessageBox.Show("위도: " + latLng.Lat + "\n경도: " + latLng.Lng, "위치 좌표");
        }

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("버튼이 클릭되었습니다!", "알림");
        }
    }
}
