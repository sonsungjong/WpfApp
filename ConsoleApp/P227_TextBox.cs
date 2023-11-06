using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P227_TextBox : Form
    {

        private Label m_lb;
        private TextBox m_tb;
        public static void Main227()
        {
            Application.Run(new P227_TextBox());
        }

        // 생성자
        public P227_TextBox()
        {
            this.Text = "Form 다이얼로그 샘플";
            this.Width = 250;
            this.Height = 200;

            m_lb = new Label();
            m_lb.Text = "어서 오세요";
            m_lb.Dock = DockStyle.Top;

            m_tb = new TextBox();
            m_tb.Dock = DockStyle.Bottom;

            m_lb.Parent = this;
            m_tb.Parent = this;

            m_tb.KeyDown += new KeyEventHandler(textBox_KeyDown);
        }

        public void textBox_KeyDown(Object sender,  KeyEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if(e.KeyCode == Keys.Enter)
            {
                m_lb.Text = temp.Text + "을(를) 선택했습니다";
            }
        }
    }
}
