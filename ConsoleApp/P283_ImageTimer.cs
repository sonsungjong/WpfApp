using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    internal class P283_ImageTimer : Form
    {
        private Image m_img;
        private int m_num;

        public static void Main283()
        {
            var app = new P283_ImageTimer();
            Application.Run(app);
        }

        public P283_ImageTimer()
        {
            this.Text = "샘플";
            this.Width = 400;
            this.Height = 300;
            this.DoubleBuffered = true;
            m_img = Image.FromFile("/logo.png");
            m_num = 0;

            Timer timer = new Timer();
            timer.Start();

            timer.Tick += new EventHandler(timer_Tick);
            this.Paint += new PaintEventHandler(fm_Paint);

        }

        public void timer_Tick(Object sender, EventArgs e)
        {
            if(m_num > m_img.Width + 200)
            {
                m_num = 0;
            }
            else
            {
                m_num = m_num + 10;
            }
            this.Invalidate();
        }

        public void fm_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(m_img, new Rectangle(0, 0, m_num, m_img.Height), 0, 0, m_num, m_img.Height, GraphicsUnit.Pixel);
        }
    }
}
