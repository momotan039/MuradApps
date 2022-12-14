using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps.Shapes_Opjects
{
    internal class Spinner : Shape
    {
        public double qutur;
        public double radius;
        public double nums;

        public Spinner(double width,double quturSpinner, double radiusSpinner,double numsSpinner) : base(width)
        {
            InitlizeImage();
            qutur = quturSpinner;
            radius = radiusSpinner;
            nums = numsSpinner;
        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 20, FontStyle.Regular);
            Brush b = Brushes.Red;
            g.DrawString("T : "+qutur, f, b, new PointF(0, 10));
            g.DrawString("n : "+nums, f, b, new PointF(120, 10));
            g.DrawString("r : "+radius, f, b, new PointF(240, 10));
            g.Dispose();
            return img;
        }
        public override double TotalLengthCm()
        {
            return width;
        }
        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/Spinner.png");
        }
    }
}
