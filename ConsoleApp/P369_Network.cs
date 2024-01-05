using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ConsoleApp
{
    internal class P369_Network : Form
    {
        private Label m_lb1, m_lb2;

        public static void Main369()
        {
            var app = new P369_Network();
            Application.Run(app);
        }

        public P369_Network()
        {
            this.Text = "네트워크 IP";
            this.Width = 300;
            this.Height = 100;

            string hn = Dns.GetHostName();
            IPHostEntry ih = Dns.GetHostEntry(hn);

            IPAddress ip_address = ih.AddressList[0];

            m_lb1 = new Label();
            m_lb2 = new Label();
            m_lb1.Width = 300;
            m_lb1.Top = 0;
            m_lb1.Text = "호스트명: " + hn;

            m_lb2.Width = 300;
            m_lb2.Top = m_lb1.Bottom;
            m_lb2.Text = "IP 주소: " + ip_address.ToString();

            m_lb1.Parent = this;
            m_lb2.Parent = this;
        }
    }
}
