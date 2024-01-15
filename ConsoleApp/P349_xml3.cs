using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    internal class P349_xml3 : Form
    {
        private ChildForm[] m_childForms;
        public static void Main349()
        {
            Application.Run(new P349_xml3());
        }

        public P349_xml3()
        {
            this.Text = "xml을 읽어 텍스트 표시하기(MDI)";
            this.Width = 400;
            this.Height = 400;
            this.IsMdiContainer = true;

            string dir = "C:\\";                // 폴더경로
            string[] fls = Directory.GetFiles(dir, "*.xml");            // 해당 폴더에서 xml 모두 가져오기
            m_childForms = new ChildForm[fls.Length];

            for(int i=0; i<fls.Length; ++i)
            {
                m_childForms[i] = new ChildForm(fls[i]);
                m_childForms[i].MdiParent = this;
                m_childForms[i].Show();
            }
        }

    }
    class ChildForm : Form
    {
        TextBox m_textBox;
        public ChildForm(string name)
        {
            this.Text = name;

            m_textBox = new TextBox();
            m_textBox.Multiline = true;
            m_textBox.Width = this.Width;
            m_textBox.Height = this.Height;

            StreamReader streamReader = new StreamReader(name, System.Text.Encoding.UTF8);
            m_textBox.Text = streamReader.ReadToEnd();
            streamReader.Close();

            m_textBox.Parent = this;
        }
    }
}
