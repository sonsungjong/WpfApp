using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P132_Array2
    {
        public static void Main1322()
        {
            Form fm = new Form();
            fm.Text = "2차원 배열로 그림 넣기";
            
            PictureBox[,] arr = new PictureBox[5, 5];

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    PictureBox path = new PictureBox();
                    path.Image = Image.FromFile("C:\\image\\logo.png");
                    path.Width = 100;
                    path.Height = 100;
                    path.Top = i * path.Width;
                    path.Left = j * path.Height;
                    path.Parent = fm;

                    arr[i, j] = path;
                }

            }
            Application.Run(fm);
        }
    }
}
