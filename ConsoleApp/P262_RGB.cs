using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApp
{
    internal class P262_RGB : Form
    {
        // 비트맵으로 이미지를 얻고 RGB값을 픽셀마다 추출한다
        private Bitmap m_bmp1, m_bmp2;
        private int m_num;

        public static void Main()
        {
            Application.Run(new P262_RGB());
        }

        public P262_RGB()
        {
            this.Width = 400;
            this.Height = 300;
            m_bmp1 = new Bitmap("/logo.png");
            m_bmp2 = new Bitmap("/logo.png");

            m_num = 0;

            this.Click += new EventHandler(formClicked);
            this.Paint += new PaintEventHandler(formPaint);
        }

        public void convert()
        {
            // 픽셀마다 색깔을 가져와서 m_num에 따라 색깔을 변경한 후 픽셀에 적용한다
            for(int x = 0; x < m_bmp2.Width; x++)
            {
                for(int y = 0; y < m_bmp1.Height; y++)
                {
                    Color color = m_bmp1.GetPixel(x, y);
                    int rgb = color.ToArgb();
                    int a = (rgb >> 24) & 0xFF;
                    int r = (rgb >> 16) & 0xFF;
                    int g = (rgb >> 8) & 0xFF;
                    int b = (rgb >> 0) & 0xFF;

                    switch (m_num)
                    {
                        case 1:
                            r >>= 2;
                            break;
                        case 2:
                            g >>= 2;
                            break;
                        case 3:
                            b >>= 2;
                            break;
                    }
                    rgb = (a << 24) | (r << 16) | (g << 8) | (b << 0);
                    color = Color.FromArgb(rgb);
                    m_bmp2.SetPixel(x, y, color);               // 픽셀마다 색깔을 바꾼다
                }
            }
        }

        public void formClicked(Object sender, EventArgs e)
        {
            m_num++;
            if(m_num >= 4)
            {
                m_num = 0;
            }
            convert();
            this.Invalidate();
        }

        public void formPaint(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(m_bmp2, 0, 0, 400, 300);
        }
    }
}
