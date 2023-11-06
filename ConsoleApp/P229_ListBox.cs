using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P229_ListBox : Form
    {
        private Label m_lb;
        private ListBox m_listBox;

        public static void Main229()
        {
            Application.Run(new P229_ListBox());
        }

        public P229_ListBox()
        {
            string[] str = { "승용차", "트럭", "오픈카", "택시", "스포츠카", "미니카", "자동차", "이륜차", "바이크", "비행기", "헬리콥터", "로켓" };

            this.Text = "Form 다이얼로그 제목";
            this.Width = 250;
            this.Height = 200;

            m_lb = new Label();
            m_lb.Text = "어서 오세요";
            m_lb.Dock = DockStyle.Top;

            m_listBox = new ListBox();

            for(int i = 0; i < str.Length; i++)
            {
                m_listBox.Items.Add(str[i]);            // 리스트박스에 항목을 추가한다.
            }
            m_listBox.Top = m_lb.Bottom;

            m_lb.Parent = this;
            m_listBox.Parent = this;

            // 리스트박스에 이벤트를 추가한다
            m_listBox.SelectedIndexChanged += new EventHandler(listBox_SelectedIndexChanged);
        }

        public void listBox_SelectedIndexChanged(Object sender, EventArgs e)
        {
            ListBox temp = (ListBox)sender;
            m_lb.Text = temp.Text + "을(를) 선택했습니다.";
        }

    }
}
