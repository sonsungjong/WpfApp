using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Odbc;

namespace ConsoleApp
{
    public class P318_FileOpen : Form
    {
        private Button m_btn;
        private Label[] m_lb = new Label[3];

        [STAThread]
        public static void Main318()
        {
            Application.Run(new P318_FileOpen());
        }

        public P318_FileOpen()
        {
            this.Text = "파일열기 창";
            this.Width = 300;
            this.Height = 200;

            for(int i=0; i<m_lb.Length; ++i)
            {
                m_lb[i] = new Label();
                m_lb[i].Top = i * m_lb[0].Height;
                m_lb[i].Width = 300;
            }

            m_btn = new Button();
            m_btn.Text = "표시";
            m_btn.Dock = DockStyle.Bottom;

            m_btn.Parent = this;
            for(int i=0; i<m_lb.Length; ++i)
            {
                m_lb[i].Parent = this;
            }

            m_btn.Click += new EventHandler(Button_Click);
        }

        // OpenFileDialog 및 파일정보
        private void Button_Click(Object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(ofd.FileName);
                m_lb[0].Text = "파일명은 " + ofd.FileName + "입니다.";
                m_lb[1].Text = "절대 경로는 " + Path.GetFullPath(ofd.FileName) +"입니다.";
                m_lb[2].Text = "크기는 " + Convert.ToString(fileInfo.Length) + "입니다.";
            }
        }
    }
}
