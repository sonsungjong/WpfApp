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
    /// Interaction logic for image_opf.xaml
    /// </summary>
    public partial class image_opf : Window
    {
        public image_opf()
        {
            InitializeComponent();
        }

        private void load_image_button_Click(object sender, RoutedEventArgs e)
        {
            //Uri image_path = new Uri("D:\\csharp\\WpfApp1\\WPF_CS\\global.png");
            Uri image_path = new Uri(this.path_label.Content.ToString());
            this.image_ctrl.Source = new BitmapImage(image_path);
        }

        // 화면에 가득 채우기
        private void fill_image_button_Click(object sender, RoutedEventArgs e)
        {
            this.image_ctrl.Stretch = System.Windows.Media.Stretch.Fill;
        }
        
        // 원본유지 맞춤형
        private void zoom_image_button_Click(object sender, RoutedEventArgs e)
        {
            this.image_ctrl.Stretch = System.Windows.Media.Stretch.Uniform;
        }

        private void browse_image_button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Title = "오픈파일다이얼로그 Select My Image to Show";                                     // 창제목
            openFileDialog.Filter = "제이피지|*.jpg;*.jpeg;*.jfif|png files (*.png)|*.png|모든 파일~|*.*";               // 필터 설정
            //openFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.System);                                      // 초기경로(System32)
            //openFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Fronts);                                      // 초기경로(폰트)
            //openFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);                                      // 초기경로(내 사진)
            openFileDialog.InitialDirectory = "C:\\Users";                                      // 초기경로
            openFileDialog.ShowDialog();

            this.path_label.Content = openFileDialog.FileName;
        }
    }
}
