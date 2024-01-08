using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TcpClientThread
{
    internal class TcpClientThread : Form
    {
        public static string m_host = "localhost";
        public static int m_port = 10001;

        private TextBox m_textBox1, m_textBox2;
        private Button m_button;

        private TcpClient? m_tcpClient;
        private StreamReader? m_streamReader;
        private StreamWriter? m_streamWriter;

        static void Main(string[] args)
        {
            Application.Run(new TcpClientThread());
        }

        public TcpClientThread()
        {
            this.Text = "TCP 클라이언트 (멀티쓰레드)";
            this.Width = 300;
            this.Height = 300;

            m_textBox1 = new TextBox();
            m_textBox2 = new TextBox();

            m_textBox1.Height = 150;
            m_textBox1.Dock = DockStyle.Top;

            m_textBox2.Multiline = true;
            m_textBox2.ScrollBars = ScrollBars.Vertical;
            m_textBox2.Height = 150;
            m_textBox2.Width = this.Width;
            m_textBox2.Top = m_textBox1.Bottom;

            m_button = new Button();
            m_button.Text = "송신";
            m_button.Dock = DockStyle.Bottom;

            m_textBox1.Parent = this;
            m_textBox2.Parent = this;
            m_button.Parent = this;

            Thread th = new Thread(this.run);
            th.Start();

            m_button.Click += new EventHandler(btn_Click);
        }

        // 보내기 버튼
        private void btn_Click(Object? sender, EventArgs e)
        {
            String str = m_textBox1.Text;
            m_streamWriter?.WriteLine(str);
            m_textBox2.AppendText(str + "\n");
            if (m_streamWriter != null)
            {
                m_streamWriter.Flush();
            }
            m_textBox1.Clear();
        }

        // 연결 및 수신은 추가쓰레드
        private void run()
        {
            m_tcpClient = new TcpClient(m_host, m_port);
            m_streamReader = new StreamReader(m_tcpClient.GetStream());
            m_streamWriter = new StreamWriter(m_tcpClient.GetStream());

            while (true)
            {
                try
                {
                    String str = m_streamReader.ReadLine() ?? "";
                    m_textBox2.Invoke((MethodInvoker)delegate {
                        m_textBox2.AppendText(str + "\n");
                    });
                }
                catch
                {
                    m_streamReader.Close();
                    m_streamWriter.Close();
                    m_tcpClient.Close();
                    break;
                }
            }
        }
    }
}
