using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P066_Property
    {
        public static void Main066()
        {
            Form fm = new Form();
            fm.Text = "샘플";

            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile("D:\\logo.png");
            pb.Top = 100;
            pb.Left = pb.Top;

            pb.Size = pb.Image.Size;
            //pb.SizeMode = PictureBoxSizeMode.StretchImage;

            pb.Parent = fm;

            Label lb = new Label();
            int a = 3;
            lb.Text = "변수 a 값은 " + a + "이다";
            lb.Parent = fm;

            Application.Run(fm);

        }
    }
}
