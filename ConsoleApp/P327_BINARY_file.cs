using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConsoleApp
{
    public class P327_BINARY_file : Form
    {
        private TextBox[] m_textBoxList = new TextBox[5];
        private Button m_btn1, m_btn2;
        private FlowLayoutPanel m_flp;

        [STAThread]
        public static void Main327()
        {
            var app = new P327_BINARY_file();
            Application.Run(app);
        }

        public P327_BINARY_file() 
        {
            this.Text = "바이너리 파일 읽고쓰기";
            this.Width = 250;
            this.Height = 200;

            for(int i=0; i< m_textBoxList.Length; ++i)
            {
                m_textBoxList[i] = new TextBox();
                m_textBoxList[i].Width = 30;
                m_textBoxList[i].Height = 30;
                m_textBoxList[i].Top = 0;
                m_textBoxList[i].Left = i * m_textBoxList[i].Width;
                m_textBoxList[i].Text = Convert.ToString(i);
            }

            m_btn1 = new Button();
            m_btn2 = new Button();
            m_btn1.Text = "읽기";
            m_btn2.Text = "저장";

            m_flp = new FlowLayoutPanel();
            m_flp.Dock = DockStyle.Bottom;

            m_btn1.Parent = m_flp;
            m_btn2.Parent = m_flp;
            m_flp.Parent = this;
            for(int i=0; i< m_textBoxList.Length; ++i)
            {
                m_textBoxList[i].Parent = this;
            }

            m_btn1.Click += new EventHandler(btn_Click);
            m_btn2.Click += new EventHandler(btn_Click);
        }

        private void btn_Click(Object sender, EventArgs e)
        {
            if(sender == m_btn1)                // 읽기 버튼
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "바이너리 파일|*.bin";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    BinaryReader br = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read));
                    for(int i = 0; i < m_textBoxList.Length; ++i)
                    {
                        int num = br.ReadInt32();           // 바이트 스트림으로부터 읽어들인다.
                        m_textBoxList[i].Text = Convert.ToString(num);
                    }
                    br.Close();
                }
            }
            else if(sender == m_btn2)               // 저장 버튼
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "바이너리 파일|*.bin";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    BinaryWriter bw = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write));
                    for(int i = 0; i < m_textBoxList.Length; ++i)
                    {
                        bw.Write(Convert.ToInt32(m_textBoxList[i].Text));
                    }
                    bw.Close();
                }
            }
            else
            {
                /* no actions */
            }
        }
    }
}
