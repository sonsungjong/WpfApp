using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P241_Modal : Form
    {
        private Label m_label;
        private Button m_btn;

        public static void Main241()
        {
            P241_Modal app = new P241_Modal();
            Application.Run(app);
        }

        public P241_Modal()
        {
            this.Text = "다이얼로그 제목";
            this.Width = 250;
            this.Height = 200;

            m_label = new Label();
            m_label.Text = "어서 오세요";
            m_label.Dock = DockStyle.Top;

            m_btn = new Button();
            m_btn.Text = "구입";
            m_btn.Dock = DockStyle.Bottom;

            m_label.Parent = this;
            m_btn.Parent = this;

            m_btn.Click += new EventHandler(button_Clicked);
        }

        public void button_Clicked(Object sender, EventArgs e)
        {
            // 새로운 다이얼로그창 생성
            SampleForm241 dlg = new SampleForm241();
            dlg.ShowDialog();
        }

    }

    class SampleForm241 : Form
    {
        public SampleForm241()
        {
            Label label = new Label();
            Button btn = new Button();

            this.Text = "사례";
            this.Width = 250;
            this.Height = 200;

            label.Text = "감사합니다";
            label.Dock = DockStyle.Top;

            btn.Text = "OK";
            btn.DialogResult = DialogResult.OK;             // OK버튼
            btn.Dock = DockStyle.Bottom;

            label.Parent = this;
            btn.Parent = this;
        }
    }
}
