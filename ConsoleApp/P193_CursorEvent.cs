using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class P193_CursorEvent : Form
    {
        private Label lb;

        public static void Main_P193_CursorEvent()
        {
            Application.Run(new P193_CursorEvent());
        }

        public P193_CursorEvent()
        {
            this.Text = "샘플";
            this.Width = 250;
            this.Height = 200;

            lb = new Label();
            lb.Text = "어서 오세요";

            lb.Parent = this;

            this.MouseEnter += new EventHandler(fm_MouseEnter);
            this.MouseLeave += new EventHandler(fm_MouseLeave);
        }

        public void fm_MouseEnter(object sender, EventArgs e)
        {
            lb.Text = "안녕하세요";
        }

        public void fm_MouseLeave(Object sender, EventArgs e)
        {
            lb.Text = "안녕히 가세요";
        }
    }
}
