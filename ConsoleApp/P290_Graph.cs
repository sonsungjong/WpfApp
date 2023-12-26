using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P290_Graph : Form
    {
        private int[] m_arr;

        public static void Main290Graph()
        {
            var app = new P290_Graph();
            Application.Run(app);
        }

        public P290_Graph()
        {
            m_arr = new int[5] { 100, 30, 50, 60, 70 };
            this.Text = "배열로부터 그래프를 그리는 프로그램";
            this.Width = 500;
            this.Height = 250;
            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(fm_Paint);
        }

        private void fm_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            SolidBrush brush1 = new SolidBrush(Color.Black);
            SolidBrush brush2 = new SolidBrush(Color.Red);
            SolidBrush brush3 = new SolidBrush(Color.Blue);
            SolidBrush brush4 = new SolidBrush(Color.Purple);
            SolidBrush brush5 = new SolidBrush(Color.Pink);
            graphics.FillRectangle(brush1, 0, 200- m_arr[0], 50, m_arr[0]);
            graphics.FillRectangle(brush2, 100, 200- m_arr[1], 50, m_arr[1]);
            graphics.FillRectangle(brush3, 200, 200- m_arr[2], 50, m_arr[2]);
            graphics.FillRectangle(brush4, 300, 200- m_arr[3], 50, m_arr[3]);
            graphics.FillRectangle(brush5, 400, 200- m_arr[4], 50, m_arr[4]);
        }
    }
}
