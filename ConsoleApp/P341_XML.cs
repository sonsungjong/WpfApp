using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;              // 추가
using System.Xml;
using System.Windows.Forms;               // 추가

// XML읽기 샘플
namespace ConsoleApp
{
    internal class P341_XML : Form
    {
        private DataSet m_dataSet;
        private DataGridView m_dataGridView;

        public static void Main341()
        {
            var app = new P341_XML();
            Application.Run(app);
        }

        public P341_XML()
        {
            this.Text = "XML 읽기 샘플";
            this.Width = 600;

            m_dataSet = new DataSet();
            m_dataSet.ReadXml("../../../Sample.xml");               // xml 읽기

            m_dataGridView = new DataGridView();
            m_dataGridView.DataSource = m_dataSet.Tables[0];

            m_dataGridView.Width = 400;
            m_dataGridView.Parent = this;
        }
    }
}
