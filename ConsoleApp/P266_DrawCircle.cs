using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P266_DrawCircle : Form
    {
        private List<Point> m_point_list;

        public static void Main266()
        {
            Application.Run(new P266_DrawCircle());
        }

        public P266_DrawCircle()
        {
            this.Text = "원 그리그";
            m_point_list = new List<Point>();

            this.MouseDown += new MouseEventHandler(form_MouseDown);
            this.Paint += new PaintEventHandler(form_Paint);
        }

        public void form_MouseDown(Object sender, MouseEventArgs e)
        {
            Point point = new Point();
            point.X = e.X;
            point.Y = e.Y;
            m_point_list.Add(point);
            this.Invalidate();
        }

        public void form_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);

            foreach(Point point in m_point_list)
            {
                graphics.DrawEllipse(pen, point.X, point.Y, 10, 10);
            }
        }
    }
}
