using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P237_MessageBox : Form
    {
        private Label m_label;
        private Button m_btn;

        public static void Main237()
        {
            P237_MessageBox app = new P237_MessageBox();
            Application.Run(app);
        }

        public P237_MessageBox()
        {
            this.Text = "메시지박스 띄우기";
            this.Width = 250;
            this.Height = 200;

            m_label = new Label();
            m_label.Text = "어서 오세요";
            m_label.Dock = DockStyle.Top;

            m_btn = new Button();
            m_btn.Text = "클릭";
            m_btn.Dock = DockStyle.Bottom;

            m_btn.Parent = this;
            m_label.Parent = this;

            m_btn.Click += new EventHandler(btn_Clicked);
        }

        public void btn_Clicked(Object sender, EventArgs e)
        {
            DialogResult messagebox_result = MessageBox.Show(m_label.Text, "메시지박스 제목", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 메시지박스 결과
            if (messagebox_result == DialogResult.Yes)
            {
                MessageBox.Show("확인버튼을 눌렀습니다", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
