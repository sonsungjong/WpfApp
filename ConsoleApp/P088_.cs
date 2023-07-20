using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class P088_
    {
        public static void Main()
        {
            Form fm = new Form();
            fm.Text = "샘플";
            fm.Width = 300;
            fm.Height = 200;

            Label lb = new Label();
            lb.Text = "안녕하세요";
            lb.Top = (fm.Width-150) / 2;
            lb.Left = fm.Height / 2;

            Label lb2 = new Label();
            Label lb3 = new Label();
            lb2.Text = "안녕";
            lb3.Text = "안녕히 가세요";

            lb3.Left = lb2.Left + 100;

            lb.Parent = fm;
            lb2.Parent = fm;
            lb3.Parent = fm;

            Application.Run(fm);

        }
    }
}
