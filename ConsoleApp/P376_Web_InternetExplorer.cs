using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P376_Web_InternetExplorer : Form
    {
        private TextBox m_textBox;
        private WebBrowser m_webBrowser;
        private ToolStrip m_toolStrip;
        private ToolStripButton[] m_toolStripButton = new ToolStripButton[4];

        [STAThread]
        public static void Main376()
        {
            Application.Run(new P376_Web_InternetExplorer());
        }

        public P376_Web_InternetExplorer()
        {
            this.Text = "Web 페이지 표시";
            this.Width = 600;
            this.Height = 400;
            m_textBox = new TextBox();
            m_textBox.Text = "http://";
            m_textBox.Dock = DockStyle.Top;

            m_webBrowser = new WebBrowser();
            m_webBrowser.Dock = DockStyle.Fill;

            m_toolStrip = new ToolStrip();
            m_toolStrip.Dock = DockStyle.Top;

            for(int i = 0; i < m_toolStripButton.Length; ++i)
            {
                m_toolStripButton[i] = new ToolStripButton();
            }

            m_toolStripButton[0].Text = "Go";
            m_toolStripButton[1].Text = "←";
            m_toolStripButton[0].ToolTipText = "이동";
            m_toolStripButton[1].ToolTipText = "돌아간다";
            m_toolStripButton[2].Text = "→";
            m_toolStripButton[3].Text = "Home";
            m_toolStripButton[2].ToolTipText = "다음 페이지로 진행한다";
            m_toolStripButton[3].ToolTipText = "홈으로 이동한다";

            m_toolStripButton[1].Enabled = false;
            m_toolStripButton[2].Enabled = false;

            for(int i=0;i<m_toolStripButton.Length; ++i)
            {
                m_toolStrip.Items.Add(m_toolStripButton[i]);
            }

            m_textBox.Parent = this;
            m_webBrowser.Parent = this;
            m_toolStrip.Parent = this;

            for (int i = 0; i < m_toolStripButton.Length; ++i)
            {
                m_toolStripButton[i].Click += new EventHandler(btn_Click);
            }

            m_webBrowser.CanGoBackChanged += new EventHandler(wb_CanGoBackChanged);
            m_webBrowser.CanGoForwardChanged += new EventHandler(wb_CanGoForwardChanged);
        }

        private void btn_Click(Object sender, EventArgs e)
        {
            if(sender == m_toolStripButton[0])
            {
                try
                {
                    Uri uri = new Uri(m_textBox.Text);
                    m_webBrowser.Url = uri;
                }
                catch
                {
                    MessageBox.Show("URL을 입력하세요");
                }
            }
            else if(sender == m_toolStripButton[1])
            {
                m_webBrowser.GoBack();
            }
            else if(sender == m_toolStripButton[2])
            {
                m_webBrowser.GoForward();
            }
            else if(sender == m_toolStripButton[3])
            {
                m_webBrowser.GoHome();
            }
        }

        private void wb_CanGoBackChanged(Object sender, EventArgs e)
        {
            m_toolStripButton[1].Enabled = m_webBrowser.CanGoBack;
        }

        private void wb_CanGoForwardChanged(Object sender, EventArgs e)
        {
            m_toolStripButton[2].Enabled = m_webBrowser.CanGoForward;
        }
    }
}
