using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P207_Panel : Form
    {
        private Button[] m_btn = new Button[6];
        private TableLayoutPanel m_tlp;             // 격자(그리드)로 배치하는 패널

        public static void Main207()
        {
            P207_Panel app = new P207_Panel();
            Application.Run(app);
        }

        public P207_Panel()
        {
            this.Text = "다이얼로그 제목";
            this.Width = 300;
            this.Height = 200;
            m_tlp = new TableLayoutPanel();
            m_tlp.Dock = DockStyle.Fill;
            m_tlp.ColumnCount = 3;              // 열 개수
            m_tlp.RowCount = 2;                 // 행 개수

            for(int i=0;i<m_btn.Length;i++)
            {
                m_btn[i] = new Button();
                m_btn[i].Text = Convert.ToString(i);
                m_btn[i].Parent = m_tlp;
            }

            m_tlp.Parent = this;
        }
    }
}
