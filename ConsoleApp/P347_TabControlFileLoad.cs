using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ConsoleApp
{
    internal class P347_TabControlFileLoad : Form
    {
        private PictureBox[] m_pictureBox;
        private TabControl m_tabControl;
        private TabPage[] m_tabPage;

        public static void Main347()
        {
            Application.Run(new P347_TabControlFileLoad());
        }

        public P347_TabControlFileLoad()
        {
            this.Text = "탭으로 파일로드";
            this.Width = 1600;
            this.Height = 600;

            m_tabControl = new TabControl();
            string dir = "C:\\Users\\LIGS\\source\\repos\\WpfApp\\";                // 폴더 경로
            string[] fls = Directory.GetFiles(dir, "*.png");                            // 해당 폴더에서 모두 가져오기

            m_pictureBox = new PictureBox[fls.Length];
            m_tabPage = new TabPage[fls.Length];

            for(int i=0; i < fls.Length; ++i)
            {
                m_pictureBox[i] = new PictureBox();
                m_tabPage[i] = new TabPage(fls[i]);

                m_pictureBox[i].Image = Image.FromFile(fls[i]);
                m_tabPage[i].Controls.Add(m_pictureBox[i]);
                m_tabControl.Controls.Add(m_tabPage[i]);

            }

            m_tabControl.Width = this.Width;
            m_tabControl.Parent = this;
        }
    }
}
