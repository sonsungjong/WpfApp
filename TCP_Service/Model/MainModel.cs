using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Service.Model
{
    public class MainModel
    {
        private string m_ui_msg;                // TCP 수신메시지
        private int m_num;                      // 메뉴 가시화여부

        public string UIMsg
        {
            get => m_ui_msg;
            set => m_ui_msg = value;
        }
        public int Num
        {
            get => m_num;
            set => m_num = value;
        }

        private static MainModel m_instance = new MainModel();
        private MainModel()
        {
        }
        public static MainModel Instance
        {
            get => m_instance;
        }
    }

    public class HelloWorld
    {
        int a;
        int b;
    }
}
