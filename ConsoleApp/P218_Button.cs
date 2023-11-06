using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P218_Button : Form
    {
        private Label m_lb;
        private Button m_btn;

        public static void Main218()
        {
            Application.Run(new P218_Button());
        }

        public P218_Button()
        {
            this.Text = "이 클래스의 Form 제목";
            this.Width = 250;           // 이 클래스의 Form 가로크기
            this.Height = 100;          // 이 클래스의 Form 세로 크기

            m_lb = new Label();
            m_lb.Text = "어서 오세요";           // 라벨 텍스트
            m_lb.Dock = DockStyle.Top;          // 컨트롤 위치

            m_btn = new Button();
            m_btn.Text = "구입";          // 버튼 텍스트
            m_btn.Dock = DockStyle.Bottom;      // 컨트롤 위치

            m_btn.Click += new EventHandler(button_Click);

            m_lb.Parent = this;
            m_btn.Parent = this;
        }

        public void button_Click(Object sender, EventArgs e)
        {
            m_lb.Text = "구입해 주셔서 감사합니다.";
            m_btn.Enabled = false;              // 버튼 활성을 무효로
        }
    }
}
