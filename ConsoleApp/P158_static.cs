using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P158_static
    {
        public static void Main158()
        {
            Form fm = new Form();
            fm.Text = "샘플";
            fm.Width = 250;
            fm.Height = 250;

            Label lb = new Label();
            Bar b1 = new Bar();
            Bar b2 = new Bar();

            lb.Width = 170;
            lb.Text = Bar.CountCar();

            lb.Parent = fm;
            Application.Run(fm);
        }
    }

    class Bar
    {
        public static int Count = 0;
        private Image img;
        private int top;
        private int left;

        public Bar()
        {
            Count++;
            img = Image.FromFile("C:\\image\\logo.png");
            top = 0;
            left = 0;
        }

        public static string CountCar()
        {
            return "자동차는 " + Count + "대 있습니다.";
        }

        public void Move()
        {
            top = top + 10;
            left = left + 10;
        }

        public void SetImage(Image i)
        {
            img = i;
        }

        public Image GetImage()
        {
            return img;
        }

        public int Top
        {
            set { top = value; }
            get { return top; }
        }

        public int Left
        {
            set { left = value; }
            get { return left; }
        }
    }
}
