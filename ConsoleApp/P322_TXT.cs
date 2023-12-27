using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConsoleApp
{
    public class P322_TXT : Form
    {
        private TextBox textBox;
        private Button btn1, btn2;
        private FlowLayoutPanel flp;

        [STAThread]
        public static void Main322txt()
        {
            // 텍스트 파일을 읽고 쓴다
            Application.Run(new P322_TXT());
        }

        public P322_TXT()
        {
            this.Text = "텍스트 파일 읽고쓰기";
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Width = this.Width;
            textBox.Height = this.Height - 100;
            textBox.Dock = DockStyle.Top;

            btn1 = new Button();
            btn1.Text = "읽기";

            btn2 = new Button();
            btn2.Text = "저장";

            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Bottom;

            btn1.Parent = flp;
            btn2.Parent = flp;
            flp.Parent = this;
            textBox.Parent = this;

            btn1.Click += new EventHandler(fm_Button_Click);
            btn2.Click += new EventHandler(fm_Button_Click);
        }

        private void fm_Button_Click(Object sender, EventArgs e)
        {
            if(sender == btn1)              // '텍스트 파일 열기'
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "텍스트 파일|*.txt";

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8);
                    textBox.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
            }
            else if(sender == btn2)             // '텍스트 파일 저장'
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "텍스트 파일|*.txt";

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(sfd.FileName);
                    streamWriter.WriteLine(textBox.Text);
                    streamWriter.Close();
                }
            }
            else
            {
                /* no actions */
            }
        }
    }
}
