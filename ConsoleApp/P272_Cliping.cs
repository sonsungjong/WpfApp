using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P272_Cliping : Form
    {
        private Image m_image;

        public static void Main272()
        {
            Application.Run(new P272_Cliping());
        }

        public P272_Cliping()
        {
            m_image = Image.FromFile("/logo.png");

            this.Text = "클리핑";

            this.ClientSize = new Size(400, 300);
            this.BackColor = Color.Black;

            this.Paint += new PaintEventHandler(form_Paint);
        }

        public void form_Paint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            GraphicsPath gp = new GraphicsPath();

            gp.AddEllipse(new Rectangle(0, 0, 200, 150));
            Region region = new Region(gp);
            graphics.Clip = region;

            graphics.DrawImage(m_image, 0, 0, 200, 150);
        }
    }
}
