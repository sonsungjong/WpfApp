using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ConsoleApp
{
    public class P290_TimerCircle : Form
    {
        private Image m_image;
        private int m_circle_width = 40;
        private int m_circle_height = 30;

        public static void Main290TimerCircle()
        {
            var app = new P290_TimerCircle();
            Application.Run(app);
        }

        public P290_TimerCircle()
        {
            this.Text = "원이 커져가는 프로그램";
            this.Width = 800;
            this.Height = 600;
            this.DoubleBuffered = true;
            m_image = Image.FromFile("../../../../cafe.png");

            Timer timer = new Timer();
            timer.Start();

            timer.Tick += new EventHandler(timer_Tick);
            this.Paint += new PaintEventHandler(fm_Paint);
        }

        private void timer_Tick(Object sender, EventArgs e)
        {
            if(m_circle_height < 300 && m_circle_width < 400)
            {
                m_circle_width += 4;
                m_circle_height += 3;
            }
            else
            {
                Timer timer = (Timer)sender;
                timer.Stop();
            }
            this.Invalidate();
        }
        private void fm_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, m_circle_width, m_circle_height);
            path.AddEllipse(rect);
            graphics.SetClip(path);

            graphics.DrawImage(m_image, rect, new Rectangle(0, 0, m_circle_width, m_circle_height), GraphicsUnit.Pixel);
            graphics.ResetClip();
        }
    }
}
