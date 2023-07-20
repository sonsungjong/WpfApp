using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class P062_
    {
        public static void Main062()
        {
            Console.WriteLine("안녕하세요");
            Console.WriteLine("안녕히 계세요");

            Form fm;
            fm = new Form();

            fm.Text = "샘플";

            Label lb = new Label();
            lb.Text = "또 만납시다!";
            lb.Parent = fm;

            Application.Run(fm);

        }
    }
}
