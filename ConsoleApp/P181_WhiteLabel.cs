using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class WhiteLabel : Label
    {
        private Color backColor;

        public Color BackColor
        {
            set { backColor = value; }
            get { return backColor; }
        }

        public static void Main181()
        {
            Form fm = new Form();
            fm.Text = "샘플";
            fm.Width = 500;
            fm.Height = 300;

            Label lb1 = new WhiteLabel();
            Label lb2 = new WhiteLabel();

            lb1.BackColor = Color.White;
            lb1.Text = "안녕하세요";
            lb1.Width = 100;
            lb1.Height = 20;

            lb2.BackColor = Color.White;
            lb2.Text = "감사합니다";
            lb2.Width = 100;
            lb2.Height = 20;
            lb2.Left += 200;

            lb2.Parent = fm;
            lb1.Parent = fm;

            Application.Run(fm);
        }

    }
}
