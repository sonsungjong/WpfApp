using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P204_Panel : Form
    {
        private Button[] btn = new Button[6];
        private FlowLayoutPanel flp;                // 가로로 컨트롤을 나열하는 패널

        public static void Main204()
        {
            P204_Panel app = new P204_Panel();
            Application.Run(app);
        }

        public P204_Panel()
        {
            this.Text = "다이얼로그 제목";
            this.Width = 600;
            this.Height = 100;

            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;

            for(int i = 0; i < btn.Length; i++)
            {
                btn[i] = new Button();
                btn[i].Text = Convert.ToString(i);
                btn[i].Parent = flp;
            }

            flp.Parent = this;
        }
    }
}
