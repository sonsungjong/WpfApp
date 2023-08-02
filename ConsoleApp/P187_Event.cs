using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsoleApp
{
    public class P187_Event : Form
    {
        private Label lb;

        public static void Main187()
        {
            Application.Run(new P187_Event());
        }

        public P187_Event()
        {
            this.Text = "샘플";
            this.Width = 250;
            this.Height = 200;
            lb = new Label();
            lb.Text = "어서 오세요";

            lb.Parent = this;

            // 이벤트 등록
            this.Click += new EventHandler(fm_Click);
        }

        public void fm_Click(Object sender, EventArgs e)
        {
            lb.Text = "안녕하세요";
        }
    }
}
