using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class P201_Event1
    {
        public static void Main_P201_Event1()
        {
            Application.EnableVisualStyles();               // Menifest
            Quiz1 quiz1 = new Quiz1();
            Application.Run(quiz1);
        }
    }

    class Quiz1 : Form
    {
        private Label lb;
        private Button btn;

        public Quiz1()
        {
            this.Text = "샘플";
            this.Width = 250;
            this.Height = 150;

            lb = new Label();
            lb.Text = "어서 오세요";
            lb.Top = 0;
            lb.Left = 0;

            btn = new Button();
            btn.Text = "구입";
            btn.Width = 100;
            btn.Top = lb.Bottom;

            btn.Click += new EventHandler(fm_Button1);

            lb.Parent = this;
            btn.Parent = this;
        }

        public void fm_Button1(Object sender, EventArgs e)
        {
            btn.Text = "감사합니다.";
        }
    }
}
