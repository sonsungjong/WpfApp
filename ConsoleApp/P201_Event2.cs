using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class P201_Event2
    {
        public static void Main()
        {
            Application.EnableVisualStyles();               // Menifest
            Quiz2 quiz2 = new Quiz2();
            Application.Run(quiz2);
        }
    }

    class Quiz2 : Form
    {
        private Button btn;
        public Quiz2()
        {

        }

    }
}
