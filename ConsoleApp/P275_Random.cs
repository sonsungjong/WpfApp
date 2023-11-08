using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P275_Random : Form
    {
        private List<Ball275> m_ball_list;

        public static void Main275()
        {
            Application.Run(new P275_Random());
        }

        public P275_Random()
        {
            this.Text = "랜덤 리스트";
            this.Paint += new PaintEventHandler(form_Paint);

            m_ball_list = new List<Ball275>();
            Random random = new Random();

            // 30개 리스트에 채워넣기
            for(int i = 0; i < 30; i++)
            {
                Ball275 ball = new Ball275();

                int x = random.Next(this.Width);
                int y = random.Next(this.Height);

                int r = random.Next(256);
                int g = random.Next(256);
                int b = random.Next(256);

                Point point = new Point(x, y);
                Color color = Color.FromArgb(r, g, b);

                ball.m_point = point;
                ball.m_color = color;

                m_ball_list.Add(ball);
            }
        }

        public void form_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            foreach(Ball275 ball in m_ball_list)
            {
                Point point = ball.m_point;
                Color color = ball.m_color;
                SolidBrush brush = new SolidBrush(color);

                graphics.FillEllipse(brush, point.X, point.Y, 10, 10);
            }
        }
    }

    class Ball275
    {
        public Color m_color;
        public Point m_point;
    }
}
