using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConsoleApp
{
    internal class P343_xml2 : Form
    {
        private TreeView m_treeView;

        public static void Main343()
        {
            Application.Run(new P343_xml2());
        }

        public P343_xml2()
        {
            this.Text = "xml 읽어 트리뷰 만들기";
            m_treeView = new TreeView();                // 트리 뷰 생성
            m_treeView.Dock = DockStyle.Fill;

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Sample.xml");                // xml 문서를 읽는다

            XmlNode xmlroot = doc.DocumentElement;      // 루트 노드를 얻는다
            TreeNode treeroot = new TreeNode();
            treeroot.Text = xmlroot.Name;       // 루트 노드를 트리노드로 변환한다
            m_treeView.Nodes.Add(treeroot);
            walk(xmlroot, treeroot);                // 자식의 처리를 시행한다
            m_treeView.Parent = this;
        }

        public static void walk(XmlNode xmlNode, TreeNode treeNode)
        {
            // 자식 순서에 대해 차례로 처리
            for(XmlNode ch = xmlNode.FirstChild; ch != null; ch = ch.NextSibling)
            {
                TreeNode n = new TreeNode();
                treeNode.Nodes.Add(n);
                walk(ch, n);            // 자식 노드에 대해 같은 처리 반복
                if(ch.NodeType == XmlNodeType.Element)
                {
                    n.Text = ch.Name;               // 요소명을 트리 노드에
                }
                else
                {
                    n.Text = ch.Value;              // 값은 트리 노드에
                }
            }
        }
    }
}
