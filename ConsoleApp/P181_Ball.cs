using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class MyBall
    {
        private int top;
        private int left;

        public MyBall()
        {
            top = 0;
            left = 0;
        }

        public void Move()
        {
            top += 10;
            left += 10;
        }

        public int Top
        {
            set { top = value; }
            get { return top;  }
        }

        public int Left
        {
            set { left = value; }
            get { return left; }
        }

        public static void Main181Ball()
        {
            Form fm = new Form();
            fm.Text = "181";
            fm.Width = 200;
            fm.Height = 200;

            MyBall mb = new MyBall();
            mb.Move();

            Label lb = new Label();
            lb.Text = "공위 위치는\nTop:"+mb.Top+"Left:"+mb.Left+"입니다.";
            lb.Width = fm.Width;
            lb.Height = fm.Height;
            lb.Parent = fm;

            Application.Run(fm);
        }

    
    }
}
