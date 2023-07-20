using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class P055_Label
    {
        public static void Main055()
        {
            Form fm = new Form();

            // WinForm 타이틀
            fm.Text = "어서 오세요 C#으로!";

            Label lb = new Label();
            lb.Width = 150;
            lb.Text = "C#을 시작합니다.";
            lb.Parent = fm;

            // 애플리케이션 실행
            Application.Run(fm);
        }
    }
}
