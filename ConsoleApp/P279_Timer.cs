using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    internal class P279_Timer
    {
        public static void Main()
        {
            TimerSample279 ts = new TimerSample279();
            Application.Run(ts);
        }
    }

    class TimerSample279 : Form
    {
        private Ball279 m_ball;
        private int m_dx, m_dy;

        public TimerSample279()
        {
            this.Text = "타이머 샘플 279";
            this.ClientSize = new Size(250, 100);

            m_ball = new Ball279();

            Point point = new Point(0, 0);
            Color color = Color.Blue;

            m_ball.BallPoint = point;
            m_ball.BallColor = color;

            m_dx = 2;
            m_dy = 2;

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();

            this.Paint += new PaintEventHandler(form_Paint);
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void form_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Point point = m_ball.BallPoint;
            Color color = m_ball.BallColor;
            SolidBrush brush = new SolidBrush(color);

            graphics.FillEllipse(brush, point.X, point.Y, 10, 10);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Point point = m_ball.BallPoint;

            if(point.X < 0 || point.X > this.ClientSize.Width - 10)
            {
                m_dx = -m_dx;
            }
            if(point.Y < 0 || point.Y > this.ClientSize.Height - 10)
            {
                m_dy = -m_dy;
            }

            point.X = point.X + m_dx;
            point.Y = point.Y + m_dy;

            m_ball.BallPoint = point;
            this.Invalidate();
        }
    }

    class Ball279
    {
        public Color BallColor { get; set; }
        public Point BallPoint { get; set; }
    }
}
