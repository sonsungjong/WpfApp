using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class P121_Array
    {
        public static void Main121()
        {
            Form fm = new Form();
            fm.Text = "샘플";
            fm.Width = 250;
            fm.Height = 100;

            Label lb = new Label();
            lb.Width = fm.Width;
            lb.Height = fm.Height;

            string[] str = new string[3] { "연필", "지우개", "자" };

            foreach(string s in str)
            {
                lb.Text += s + "\n";
            }

            lb.Parent = fm;

            Application.Run(fm);
        }
    }
}
