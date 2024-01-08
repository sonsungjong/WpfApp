using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp
{
    internal class P372_Network2 : Form
    {
        private TextBox m_textBox;
        private Label[] m_labels = new Label[5];
        private Button m_btn;
        private TableLayoutPanel m_tableLayoutPanel;

        public static void Main372()
        {
            var app = new P372_Network2();
            Application.Run(app);
        }

        public P372_Network2() 
        {
            this.Text = "네트워크 기초2";
            this.Width = 300;
            this.Height = 200;

            m_textBox = new TextBox();
            m_textBox.Dock = DockStyle.Fill;

            m_btn = new Button();
            m_btn.Width = this.Width;
            m_btn.Text = "검색";
            m_btn.Dock = DockStyle.Bottom;

            m_tableLayoutPanel = new TableLayoutPanel();
            m_tableLayoutPanel.Dock = DockStyle.Fill;

            for(int i=0; i < m_labels.Length; ++i)
            {
                m_labels[i] = new Label();
                m_labels[i].Dock = DockStyle.Fill;
            }

            m_tableLayoutPanel.ColumnCount = 2;
            m_tableLayoutPanel.RowCount = 3;

            m_labels[0].Text = "입력하세요";
            m_labels[1].Text = "호스트명: ";
            m_labels[3].Text = "IP 주소: ";

            m_labels[0].Parent = m_tableLayoutPanel;
            m_textBox.Parent = m_tableLayoutPanel;

            for (int i = 1; i<m_labels.Length;++i)
            {
                m_labels[i].Parent = m_tableLayoutPanel;
            }

            m_btn.Parent = this;
            m_tableLayoutPanel.Parent = this;

            m_btn.Click += new EventHandler(btn_Click);
        }

        private void btn_Click(Object sender, EventArgs e)
        {
            try
            {
                IPHostEntry ih = Dns.GetHostEntry(m_textBox.Text);
                IPAddress ip_address = ih.AddressList[0];

                m_labels[2].Text = ih.HostName;
                m_labels[4].Text = ip_address.ToString();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch
            {
                MessageBox.Show("오류가 발생했습니다.");
            }
        }
    }
}
