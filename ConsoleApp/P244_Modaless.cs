using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P244_Modaless : Form
    {
        private Label m_label;
        private Button m_btn;

        public static void Main244()
        {
            P244_Modaless app = new P244_Modaless();
            Application.Run(app);
        }

        public P244_Modaless()
        {
            this.Text = "모달리스 샘플";
            this.Width = 250;
            this.Height = 200;

            m_label = new Label();
            m_btn = new Button();

            m_label.Text = "어서 오세요";
            m_label.Dock = DockStyle.Top;

            m_btn.Text = "구입";
            m_btn.Dock = DockStyle.Bottom;

            m_label.Parent = this;
            m_btn.Parent = this;

            m_btn.Click += new EventHandler(Button_Clicked);
        }

        public void Button_Clicked(Object sender, EventArgs e)
        {
            SampleForm244 sf = new SampleForm244();
            sf.Show();              // Show : 모달리스 , ShowDialog : 모달
        }

        class SampleForm244 : Form
        {
            public SampleForm244()
            {
                Label label = new Label();
                Button btn = new Button();

                this.Text = "신규";
                this.Width = 250;
                this.Height = 200;

                label.Text = "새로운 가게를 시작했습니다.";
                label.Dock = DockStyle.Top;

                btn.Text = "OK";
                btn.Dock = DockStyle.Bottom;

                label.Parent = this;
                btn.Parent = this;

                btn.Click += new EventHandler(modalessButton);
            }

            public void modalessButton(Object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
}
