using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P224_RadioButton : Form
    {
        private Label m_lb;
        private RadioButton m_rb1, m_rb2;
        private GroupBox m_gb;

        public static void Main224()
        {
            Application.Run(new P224_RadioButton());
        }

        public P224_RadioButton()
        {
            this.Text = "샘플";
            this.Width = 300;
            this.Height = 200;

            m_lb = new Label();
            m_lb.Text = "어서 오세요";
            m_lb.Dock = DockStyle.Top;

            m_rb1 = new RadioButton();
            m_rb2 = new RadioButton();

            m_rb1.Text = "자동차";
            m_rb2.Text = "트럭";
            m_rb1.Checked = true;

            m_rb1.Dock = DockStyle.Left;
            m_rb2.Dock = DockStyle.Right;

            m_gb = new GroupBox();
            m_gb.Text = "종류";
            m_gb.Dock = DockStyle.Bottom;

            // 그룹박스에 라디오버튼을 추가한다
            m_rb1.Parent = m_gb;
            m_rb2.Parent = m_gb;

            m_lb.Parent = this;
            m_gb.Parent = this;

            m_rb1.Click += new EventHandler(radioButton_Click);
            m_rb2.Click += new EventHandler(radioButton_Click);
        }

        public void radioButton_Click(Object sender, EventArgs e)
        {
            RadioButton tmp = (RadioButton)sender;
            m_lb.Text = tmp.Text + "을(를) 선택했습니다";
        }
    }
}
