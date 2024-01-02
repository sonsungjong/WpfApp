using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P332_ImageFile : Form
    {
        private Button m_btn1, m_btn2;
        private FlowLayoutPanel m_flp;
        private Bitmap m_bmp;

        [STAThread]
        public static void Main332()
        {
            Application.Run(new P332_ImageFile());
        }

        public P332_ImageFile()
        {
            this.Text = "이미지 파일 읽고쓰기";
            this.Width = 400;
            this.Height = 300;

            m_bmp = new Bitmap(400, 300);

            m_btn1 = new Button();
            m_btn2 = new Button();
            m_btn1.Text = "읽어 들이기";
            m_btn2.Text = "저장";

            m_flp = new FlowLayoutPanel();
            m_flp.Dock = DockStyle.Bottom;

            m_btn1.Parent = m_flp;
            m_btn2.Parent = m_flp;
            m_flp.Parent = this;

            m_btn1.Click += new EventHandler(btn_Click);
            m_btn2.Click += new EventHandler(btn_Click);
            this.Paint += new PaintEventHandler(form_Paint);
        }

        private void btn_Click(Object sender, EventArgs e)
        {
            if(sender == m_btn1)                // 읽기 버튼
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "비트맵 파일|*.bmp|JPEG 파일|*.jpg|PNG 파일|*.png";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image temp = (Bitmap)Image.FromFile(openFileDialog.FileName);
                    m_bmp = new Bitmap(temp);
                }
            }
            else if(sender == m_btn2)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "비트맵 파일|*.bmp|JPEG 파일|*.jpg|PNG 파일|*.png";
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FilterIndex == 1)                // bmp
                    {
                        m_bmp.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                    }
                    else if (saveFileDialog.FilterIndex == 2)           // jpg
                    {
                        m_bmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                    }
                    else if (saveFileDialog.FilterIndex == 3)           // png
                    {
                        m_bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
                    }
                }
            }
            this.Invalidate();
        }

        private void form_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(m_bmp, 0, 0);
        }
    }
}
