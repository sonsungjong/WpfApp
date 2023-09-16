using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{

    public class P191_ButtonEvent : Form
    {
        private Label lb;
        private Button btn;

        public static void Main_191Button()
        {
            Application.Run(new P191_ButtonEvent());
        }

        public P191_ButtonEvent()
        {
            this.Text = "샘플";
            this.Width = 250;
            this.Height = 100;

            lb = new Label();
            lb.Text = "어서 오세요";
            lb.Width = 150;

            btn = new Button();
            btn.Text = "구입";
            btn.Top = this.Top + lb.Height;
            btn.Width = lb.Width;

            btn.Parent = this;
            lb.Parent = this;

            btn.Click += new EventHandler(btn_Click);
        }

        public void btn_Click(Object sender, EventArgs e)
        {
            if(lb.Text == "어서 오세요")
            {
                lb.Text = "다시 만나요";
            }
            else if(lb.Text == "다시 만나요")
            {
                lb.Text = "어서 오세요";
            }
        }
    }
}
