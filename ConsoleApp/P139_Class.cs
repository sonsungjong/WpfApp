using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    public class P139_Class
    {
        public static void Main139()
        {
            Form fm = new Form();
            fm.Text = "샘플";
            fm.Width = 300;
            fm.Height = 200;
            PictureBox pb = new PictureBox();

            Car car = new Car();
            car.Move();
            car.Move();

            pb.Image = car.GetImage();
            pb.Top = car.Top;
            pb.Left = car.Left;

            pb.Parent = fm;
            Application.Run(fm);

        }
    }
}

class Car
{
    private Image img;
    private int top;
    private int left;

    public Car()
    {
        img = Image.FromFile("C:\\image\\logo.png");
        top = 0;
        left = 0;
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
    
    // 프로퍼티
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
