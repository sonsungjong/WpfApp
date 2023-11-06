using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    internal class P249_RadioButton : Form
    {
        RadioButton m_radio_button1, m_radio_button2, m_radio_button3;
        Label m_label;
        GroupBox m_group_box;
        public static void Main249()
        {
            Application.Run(new P249_RadioButton());
        }

        public P249_RadioButton()
        {
            m_label = new Label();
            m_radio_button1 = new RadioButton();
            m_radio_button2 = new RadioButton();
            m_radio_button3 = new RadioButton();
            m_group_box = new GroupBox();

            this.Text = "샘플";
            this.Width = 250;
            this.Height = 200;

            m_label.Text = "어서 오세요";
            m_label.Dock = DockStyle.Top;

            m_radio_button1.Text = "노란색 보통";
            m_radio_button2.Text = "빨간색 볼드체";
            m_radio_button3.Text = "파란색 이탤릭체";

            m_radio_button2.Dock = DockStyle.Top;
            m_radio_button1.Dock = DockStyle.Top;
            m_radio_button3.Dock = DockStyle.Bottom;

            m_radio_button1.Parent = m_group_box;
            m_radio_button2.Parent = m_group_box;
            m_radio_button3.Parent = m_group_box;

            m_group_box.Dock = DockStyle.Bottom;

            m_group_box.Parent = this;
            m_label.Parent = this;

            m_radio_button1.Click += new EventHandler(RadioButtonClicked);
            m_radio_button2.Click += new EventHandler(RadioButtonClicked);
            m_radio_button3.Click += new EventHandler(RadioButtonClicked);
        }

        public void RadioButtonClicked(Object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;
            if(temp == m_radio_button1)
            {
                m_label.Text = "노란색";
                m_label.ForeColor = Color.Yellow;
                m_label.Font = new Font("Arial", 12, FontStyle.Regular);
            }
            else if(temp == m_radio_button2)
            {
                m_label.Text = "빨간색";
                m_label.ForeColor = Color.Red;
                m_label.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            else if (temp == m_radio_button3)
            {
                m_label.Text = "파란색";
                m_label.ForeColor = Color.Blue;
                m_label.Font = new Font("Arial", 12, FontStyle.Italic);
            }
        }
    }
}
