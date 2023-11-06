using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    internal class P253_ImageRotation : Form
    {
        private Image m_image;

        public static void Main253()
        {
            P253_ImageRotation app = new P253_ImageRotation();
            Application.Run(app);
        }

        public P253_ImageRotation()
        {
            this.Width = 250;
            this.Height = 200;

            m_image = Image.FromFile("/logo.png");          // 프로젝트파일 경로

            this.Paint += new PaintEventHandler(fmPaint);
            this.Click += new EventHandler(fmClicked);
        }

        public void fmPaint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(m_image, 0, 0);
        }

        public void fmClicked(Object sender, EventArgs e)
        {
            m_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.Invalidate();
        }
    }
}
