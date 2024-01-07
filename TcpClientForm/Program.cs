using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TcpClientForm
{
    internal class Program : Form
    {
        public static string m_host = "localhost";
        public static int m_port = 10000;

        private TextBox m_textBox;
        private Button m_button;

        static void Main(string[] args)
        {
            Application.Run(new Program());
        }

        public Program()
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

        private void btn_Click(Object? sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient(m_host, m_port);            // 아이피와 포트를 생성자에
            using StreamReader streamReader = new StreamReader(tcpClient.GetStream());
            string str = streamReader.ReadLine() ?? "";               // 수신 (null이면 "" 로 채워라)

            m_textBox.Text = str;

            // streamReader.Close();                // using 을 써서 명시적으로 Close할 필요가 없음
            tcpClient.Close();              // 접속 해제
        }
    }
}
