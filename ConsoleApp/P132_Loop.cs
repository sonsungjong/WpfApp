using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P132_Loop
    {
        public static void Main132Loop()
        {
            Form fm = new Form();
            fm.Text = "1번";
            fm.Width = 250;
            fm.Height = 150;

            Label lb = new Label();
            lb.Width = fm.Width;
            lb.Height = fm.Height;

            int i = 2;
            while (i < 11)
            {
                lb.Text += (i + "을(를) 표시합니다.\n");

                i += 2;
            }

            lb.Parent = fm;
            Application.Run(fm);
        }
    }
}
