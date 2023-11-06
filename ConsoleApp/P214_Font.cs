using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P214_Font : Form
    {
        private Label[] m_lb = new Label[3];
        private TableLayoutPanel m_tlp;

        public static void Main214()
        {
            P214_Font app = new P214_Font();
            Application.Run(app);
        }

        public P214_Font()
        {
            this.Text = "샘플";
            this.Width = 250;
            this.Height = 200;

            m_tlp = new TableLayoutPanel();
            m_tlp.ColumnCount = 1;
            m_tlp.RowCount = 3;

            for(int i = 0; i < m_lb.Length; i++)
            {
                m_lb[i] = new Label();
                m_lb[i].Text = "This is a Car";
                m_lb[i].Width = 200;
            }

            m_lb[0].Font = new Font("Arial", 12, FontStyle.Bold);
            m_lb[1].Font = new Font("Times New Roman", 14, FontStyle.Bold);
            m_lb[2].Font = new Font("Courier New", 16, FontStyle.Bold);

            for(int i=0; i < m_lb.Length; i++)
            {
                m_lb[i].Parent = m_tlp;
            }
            m_tlp.Parent = this;
        }
    }
}
