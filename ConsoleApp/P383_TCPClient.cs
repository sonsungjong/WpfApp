using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace ConsoleApp
{
    internal class P383_TCPClient : Form
    {
        public static string m_host = "localhost";
        public static int m_port = 10000;

        private TextBox m_textBox;
        private Button m_button;

        public static void Main383()
        {
            Application.Run(new P383_TCPClient());
        }

        public P383_TCPClient()
        {
            this.Text = "TCP 클라이언트";
            this.Width = 300;
            this.Height = 300;

            m_textBox = new TextBox();
            m_textBox.Multiline = true;
            m_textBox.ScrollBars = ScrollBars.Vertical;
            m_textBox.Height = 150;
            m_textBox.Dock = DockStyle.Top;

            m_button = new Button();
            m_button.Text = "접속";
            m_button.Dock = DockStyle.Bottom;

            m_textBox.Parent = this;
            m_button.Parent = this;

            m_button.Click += new EventHandler(btn_Click);
        }

        private void btn_Click(Object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient(m_host, m_port);            // 아이피와 포트를 생성자에
            StreamReader streamReader = new StreamReader(tcpClient.GetStream());
            String str = streamReader.ReadLine();               // 수신

            m_textBox.Text = str;

            streamReader.Close();
            tcpClient.Close();              // 접속 해제
        }
    }
}
