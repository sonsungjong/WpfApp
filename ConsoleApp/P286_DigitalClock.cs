using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    internal class P286_DigitalClock : Form
    {
        private Label m_label;

        public static void Main286()
        {
            var app = new P286_DigitalClock();
            Application.Run(app);
        }

        public P286_DigitalClock()
        {
            this.Text = "샘플";
            this.Width = 250;
            this.Height = 100;

            Timer timer = new Timer();
            timer.Interval = 1000;              // 1초 타이머
            timer.Start();

            m_label = new Label();
            m_label.Font = new Font("Courier", 20, FontStyle.Regular);
            m_label.Dock = DockStyle.Fill;

            m_label.Parent = this;

            timer.Tick += new EventHandler(timer_Tick);
        }

        public void timer_Tick(Object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            m_label.Text = dateTime.ToLongTimeString();
        }
    }
}
