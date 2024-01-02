using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class TextEditorApp : Form
    {
        private TextBox m_text_box;
        private ToolStrip m_tool_strip;
        private ToolStripButton[] m_tool_strip_button = new ToolStripButton[3];
        private Button m_btn1, m_btn2;
        private FlowLayoutPanel m_flp;

        [STAThread]
        public static void Main335()
        {
            var app = new TextEditorApp();
            Application.Run(app);
        }

        public TextEditorApp()
        {
            this.Text = "텍스트 에디터 프로그램";
            this.Width = 500;
            this.Height = 400;

            m_tool_strip = new ToolStrip();
            for(int i=0; i < m_tool_strip_button.Length; ++i)
            {
                m_tool_strip_button[i] = new ToolStripButton();
            }

            m_tool_strip_button[0].Image = Image.FromFile("d:\\csharp\\WpfApp1\\Cut.png");
            m_tool_strip_button[1].Image = Image.FromFile("d:\\csharp\\WpfApp1\\Copy.png");
            m_tool_strip_button[2].Image = Image.FromFile("d:\\csharp\\WpfApp1\\Paste.png");

            m_tool_strip_button[0].ToolTipText = "잘라내기";
            m_tool_strip_button[1].ToolTipText = "복사하기";
            m_tool_strip_button[2].ToolTipText = "붙여넣기";

            m_text_box = new TextBox();
            m_text_box.Multiline = true;
            m_text_box.Width = this.Width;
            m_text_box.Height = this.Height - 100;
            m_text_box.Dock = DockStyle.Top;

            m_btn1 = new Button();
            m_btn2 = new Button();
            m_btn1.Text = "읽기";
            m_btn2.Text = "쓰기";

            m_flp = new FlowLayoutPanel();
            m_flp.Dock = DockStyle.Bottom;

            for(int i = 0; i < m_tool_strip_button.Length; ++i)
            {
                m_tool_strip.Items.Add(m_tool_strip_button[i]);
            }

            m_btn1.Parent = m_flp;
            m_btn2.Parent = m_flp;
            m_flp.Parent = this;
            m_text_box.Parent = this;
            m_tool_strip.Parent = this;

            m_btn1.Click += new EventHandler(btn_Click);
            m_btn2.Click += new EventHandler(btn_Click);

            for(int i=0; i < m_tool_strip_button.Length; ++i)
            {
                m_tool_strip_button[i].Click += new EventHandler(tsb_Click);
            }
        }

        private void tsb_Click(Object sender, EventArgs e)
        {
            if(sender == m_tool_strip_button[0])                // 잘라내기
            {
                m_text_box.Cut();
            }
            else if(sender == m_tool_strip_button[1])           // 복사하기
            {
                m_text_box.Copy();
            }
            else if(sender == m_tool_strip_button[2])               // 붙여넣기
            {
                m_text_box.Paste();
            }
        }

        private void btn_Click(Object sender, EventArgs e)
        {
            if(sender == m_btn1)                // 읽기 버튼
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "텍스트 파일|*.txt";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName, System.Text.Encoding.UTF8);
                    m_text_box.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
            }
            else if(sender == m_btn2)               // 저장 버튼
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "텍스트 파일|*.txt";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.WriteLine(m_text_box.Text);
                    streamWriter.Close();
                }
            }
        }
    }
}
