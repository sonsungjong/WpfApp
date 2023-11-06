using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;

namespace ConsoleApp
{
    internal class P257_ImageZoom : Form
    {
        private Image m_image;
        private RadioButton m_radio_button1, m_radio_button2, m_radio_button3;
        private GroupBox m_group_box;
        private int m_num = 1;

        public static void Main257()
        {
            Application.Run(new P257_ImageZoom());
        }

        public P257_ImageZoom()
        {
            this.Width = 300;
            this.Height = 300;

            m_image = Image.FromFile("/logo.png");

            m_radio_button1 = new RadioButton();
            m_radio_button2 = new RadioButton();
            m_radio_button3 = new RadioButton();

            m_radio_button1.Text = "보통";
            m_radio_button2.Text = "확대";
            m_radio_button3.Text = "축소";

            m_radio_button1.Dock = DockStyle.Bottom;
            m_radio_button2.Dock = DockStyle.Bottom;
            m_radio_button3.Dock = DockStyle.Bottom;

            m_group_box = new GroupBox();
            m_group_box.Text = "종류";
            m_group_box.Dock = DockStyle.Bottom;

            m_radio_button1.Parent = m_group_box;
            m_radio_button2.Parent = m_group_box;
            m_radio_button3.Parent = m_group_box;
            m_group_box.Parent = this;

            m_radio_button1.Click += new EventHandler(radioButtonClicked);
            m_radio_button2.Click += new EventHandler(radioButtonClicked);
            m_radio_button3.Click += new EventHandler(radioButtonClicked);
            this.Paint += new PaintEventHandler(fmPaint);
        }

        public void fmPaint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if(m_num == 1)
            {
                graphics.DrawImage(m_image, 0, 0, 100, 100);
            }
            else if(m_num == 2)
            {
                graphics.DrawImage(m_image, 0, 0, 200, 200);
            }
            else if(m_num == 3)
            {
                graphics.DrawImage(m_image, 0, 0, 50, 50);
            }
        }

        public void radioButtonClicked(Object sender, EventArgs e)
        {
            RadioButton control = (RadioButton)sender;
            if(control == m_radio_button1)
            {
                m_num = 1;
            }else if(control == m_radio_button2)
            {
                m_num = 2;
            }else if(control == m_radio_button3)
            {
                m_num = 3;
            }
            this.Invalidate();
        }
    }
}
