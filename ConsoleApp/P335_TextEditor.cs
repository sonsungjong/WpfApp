using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P335_TextEditor : Form
    {
        private TextBox m_textBox;
        private ToolStrip m_toolStrip;
        private ToolStripButton[] m_toolStripButton = new ToolStripButton[3];
        private Button m_btn1, m_btn2;
        private FlowLayoutPanel m_flowLayoutPanel;

        [STAThread]
        public static void Main335()
        {
            Application.Run(new P335_TextEditor());
        }

        public P335_TextEditor()
        {
            this.Text = "텍스트 에디터";

            m_toolStrip = new ToolStrip();
            for(int i = 0; i < m_toolStripButton.Length; ++i)
            {
                m_toolStripButton[i] = new ToolStripButton();
            }
            m_toolStripButton[0].Image = Image.FromFile("/logo.png");
            m_toolStripButton[1].Image = Image.FromFile("/logo.png");
            m_toolStripButton[2].Image = Image.FromFile("/logo.png");

            m_toolStripButton[0].ToolTipText = "잘라내기";
            m_toolStripButton[1].ToolTipText = "복사";
            m_toolStripButton[2].ToolTipText = "붙여넣기";

            m_textBox = new TextBox();
            m_textBox.Multiline = true;
            m_textBox.Width = this.Width;
            m_textBox.Height = this.Height - 100;
            m_textBox.Dock = DockStyle.Top;

            m_btn1 = new Button();
            m_btn2 = new Button();
            m_btn1.Text = "읽어 들이기";
            m_btn2.Text = "저장";

            m_flowLayoutPanel = new FlowLayoutPanel();
            m_flowLayoutPanel.Dock = DockStyle.Bottom;

            for(int i = 0; i < m_toolStripButton.Length; ++i)
            {
                m_toolStrip.Items.Add(m_toolStripButton[i]);
            }

            m_btn1.Parent = m_flowLayoutPanel;
            m_btn2.Parent = m_flowLayoutPanel;
            m_flowLayoutPanel.Parent = this;
            m_textBox.Parent = this;
            m_toolStrip.Parent = this;

            m_btn1.Click += new EventHandler(btn_Click);
            m_btn2.Click += new EventHandler(btn_Click);

            for(int i = 0; i < m_toolStripButton.Length; ++i)
            {
                m_toolStripButton[i].Click += new EventHandler(toolStripButton_Click);
            }
        }

        private void toolStripButton_Click(Object sender, EventArgs e)
        {
            if(sender == m_toolStripButton[0])
            {
                m_textBox.Cut();
            }
            else if(sender == m_toolStripButton[1])
            {
                m_textBox.Copy();
            }
            else if(sender == m_toolStripButton[2])
            {
                m_textBox.Paste();
            }
        }

        private void btn_Click(Object sender, EventArgs e)
        {
            if(sender == m_btn1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "텍스트 파일|*.txt";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName, System.Text.Encoding.UTF8);
                    m_textBox.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
            }
            else if(sender == m_btn2)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "텍스트 파일|*.txt";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.WriteLine(m_textBox.Text);
                    streamWriter.Close();
                }
            }
        }
    }
}
