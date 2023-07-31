using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P119_Array
    {
        public static void Main119()
        {
            Form fm = new Form();
            fm.Text = "샘플";

            PictureBox[] pb = new PictureBox[5];
            for(int i=0; i < pb.Length; i++)
            {
                pb[i] = new PictureBox();
                pb[i].Image = Image.FromFile("C:\\image\\logo.png");
                pb[i].Top = i * pb[i].Height;
                pb[i].Parent = fm;
            }

            Application.Run(fm);
        }
    }
}
