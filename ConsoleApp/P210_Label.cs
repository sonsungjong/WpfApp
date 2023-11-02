using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P210_Label : Form
    {
        private Label[] m_lb = new Label[3];
        private TableLayoutPanel m_tlp;

        public static void Main210()
        {
            P210_Label app = new P210_Label();
            app.initLabelMethod();
            Application.Run(app);
        }

        public P210_Label()
        {
            
        }

        public void initLabelMethod()
        {
            this.Text = "다이얼로그 제목";
            this.Width = 250;
            this.Height = 200;

            m_tlp = new TableLayoutPanel();
            m_tlp.Dock = DockStyle.Fill;
            m_tlp.ColumnCount = 1;
            m_tlp.RowCount = 3;

            for(int i=0; i < m_lb.Length; i++)
            {
                m_lb[i] = new Label();
                m_lb[i].Text = i + "호 자동차";
            }

            // 텍스트 글자색
            m_lb[0].ForeColor = Color.Black;
            m_lb[1].ForeColor = Color.Black;
            m_lb[2].ForeColor = Color.Black;

            // 텍스트 배경색
            m_lb[0].BackColor = Color.White;
            m_lb[1].BackColor = Color.Gray;
            m_lb[2].BackColor = Color.White;

            // 텍스트 정렬
            m_lb[0].TextAlign = ContentAlignment.TopLeft;
            m_lb[1].TextAlign = ContentAlignment.MiddleCenter;
            m_lb[2].TextAlign = ContentAlignment.BottomRight;

            // 테두리 스타일
            m_lb[0].BorderStyle = BorderStyle.None;
            m_lb[1].BorderStyle = BorderStyle.FixedSingle;
            m_lb[2].BorderStyle = BorderStyle.Fixed3D;

            for(int i = 0; i < m_lb.Length; i++)
            {
                m_lb[i].Parent = m_tlp;
            }

            m_tlp.Parent = this;
        }
    }
}
