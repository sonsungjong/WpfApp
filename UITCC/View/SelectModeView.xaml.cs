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
using System.Windows.Forms;
using System.Drawing;

namespace UITCC.View
{
    /// <summary>
    /// Interaction logic for SelectModeView.xaml
    /// </summary>
    public partial class SelectModeView : Window
    {
        public SelectModeView()
        {
            InitializeComponent();

            int monitor_index = 0;

            Screen[] screens = Screen.AllScreens;

            // 선택한 모니터가 유효한지 확인
            if (monitor_index >= 0 && monitor_index < screens.Length)
            {
                Screen screen = screens[monitor_index];

                // 창 위치와 크기 설정
                //this.Left = screen.WorkingArea.Left;
                //this.Top = screen.WorkingArea.Top;
                //this.Width = screen.WorkingArea.Width;
                //this.Height = screen.WorkingArea.Height;
            }
        }

    }
}
