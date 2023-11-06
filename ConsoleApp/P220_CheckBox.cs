using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P220_CheckBox : Form
    {
        private Label m_lb;
        private CheckBox m_cb1, m_cb2;
        private FlowLayoutPanel m_flp;

        public static void Main_220()
        {
            P220_CheckBox app = new P220_CheckBox();
            Application.Run(app);
        }

        public P220_CheckBox()
        {
            this.Text = "Form 제목";
            this.Width = 250;
            this.Height = 200;

            m_lb = new Label();
            m_lb.Text = "어서 오세요";
            m_lb.Dock = DockStyle.Top;

            m_cb1 = new CheckBox();
            m_cb2 = new CheckBox();

            m_cb1.Text = "자동차";
            m_cb2.Text = "트럭";

            m_flp = new FlowLayoutPanel();
            m_flp.Dock = DockStyle.Bottom;

            m_cb1.Parent = m_flp;
            m_cb2.Parent = m_flp;

            m_lb.Parent = this;
            m_flp.Parent = this;

            m_cb1.CheckedChanged += new EventHandler(checkBoxChanged);
            m_cb2.CheckedChanged += new EventHandler(checkBoxChanged);
        }

        public void checkBoxChanged(Object sender, EventArgs e)
        {
            CheckBox tmp = (CheckBox)sender;
            if(tmp.Checked == true)
            {
                m_lb.Text = tmp.Text + "을(를) 선택했습니다.";
            }
            else if(tmp.Checked == false)
            {
                m_lb.Text = tmp.Text + "을(를) 해제했습니다.";
            }
        }

    }
}
