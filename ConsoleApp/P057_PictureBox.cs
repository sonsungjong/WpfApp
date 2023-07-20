using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P057_PictureBox
    {
        public static void Main057()
        {
            Form fm = new Form();
            fm.Text = "제목";

            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile("d:\\logo.png");
            pb.Parent = fm;

            Application.Run(fm);

        }
    }
}
