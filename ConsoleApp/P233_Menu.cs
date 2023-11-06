using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    internal class P233_Menu : Form
    {
        private Label m_label;
        private MenuStrip m_menu_strip;
        private ToolStripMenuItem[] m_tool_strip_menu_item = new ToolStripMenuItem[10];

        public static void Main233() 
        { 
            Application.Run(new P233_Menu());
        }

        public P233_Menu()
        {
            this.Text = "샘플";
            this.Width = 250;
            this.Height = 200;

            m_label = new Label();
            m_label.Text = "어서 오세요";
            m_label.Dock = DockStyle.Bottom;

            m_menu_strip = new MenuStrip();
            m_tool_strip_menu_item[0] = new ToolStripMenuItem("메인1");
            m_tool_strip_menu_item[1] = new ToolStripMenuItem("메인2");
            m_tool_strip_menu_item[2] = new ToolStripMenuItem("서브1");
            m_tool_strip_menu_item[3] = new ToolStripMenuItem("서브2");
            m_tool_strip_menu_item[4] = new ToolStripMenuItem("승용차");
            m_tool_strip_menu_item[5] = new ToolStripMenuItem("트럭");
            m_tool_strip_menu_item[6] = new ToolStripMenuItem("오픈카");
            m_tool_strip_menu_item[7] = new ToolStripMenuItem("택시");
            m_tool_strip_menu_item[8] = new ToolStripMenuItem("스포츠카");
            m_tool_strip_menu_item[9] = new ToolStripMenuItem("미니카");

            m_tool_strip_menu_item[0].DropDownItems.Add(m_tool_strip_menu_item[4]);
            m_tool_strip_menu_item[0].DropDownItems.Add(m_tool_strip_menu_item[5]);

            m_tool_strip_menu_item[1].DropDownItems.Add(m_tool_strip_menu_item[2]);
            m_tool_strip_menu_item[1].DropDownItems.Add(new ToolStripSeparator());              // 세퍼레이터(구분선)
            m_tool_strip_menu_item[1].DropDownItems.Add(m_tool_strip_menu_item[3]);

            m_tool_strip_menu_item[2].DropDownItems.Add(m_tool_strip_menu_item[6]);
            m_tool_strip_menu_item[2].DropDownItems.Add(m_tool_strip_menu_item[7]);

            m_tool_strip_menu_item[3].DropDownItems.Add(m_tool_strip_menu_item[8]);
            m_tool_strip_menu_item[3].DropDownItems.Add(m_tool_strip_menu_item[9]);

            m_menu_strip.Items.Add(m_tool_strip_menu_item[0]);
            m_menu_strip.Items.Add(m_tool_strip_menu_item[1]);

            this.MainMenuStrip = m_menu_strip;

            m_menu_strip.Parent = this;
            m_label.Parent = this;

            // 4번째 메뉴버튼부터 클릭이벤트 추가
            for(int i = 4; i < m_tool_strip_menu_item.Length; i++)
            {
                m_tool_strip_menu_item[i].Click += new EventHandler(menuItemClick);
            }


        }
        public void menuItemClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem menu_item = (ToolStripMenuItem)sender;
            m_label.Text = menu_item.Text + "입니다";
        }
    }
}
