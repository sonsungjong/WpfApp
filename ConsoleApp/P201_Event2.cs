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
        public static void Main201_2()
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
            this.Text = "다이얼로그 제목";
            this.Width = 250;
            this.Height = 100;

            btn = new Button();
            btn.Text = "어서 오세요";
            btn.Width = 150;
            btn.Height = 50;

            btn.Parent = this;
            btn.MouseEnter += new EventHandler(fm_MouseEnter);
            btn.MouseLeave += new EventHandler(fm_MouseLeave);
        }

        public void fm_MouseEnter(Object sender, EventArgs e)
        {
            String str = "안녕하세요";
            btn.Text = str;
        }

        public void fm_MouseLeave(Object sender, EventArgs e)
        {
            String str = "안녕히 가세요";
            btn.Text = str;
        }
    }
}
