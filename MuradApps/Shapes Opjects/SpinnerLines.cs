using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps.Shapes_Opjects
{
    internal class SpinnerLines : Line
    {
        public double qutur;
        public double radius;
        public double nums;

        public SpinnerLines(double width,double quturSpinner, double radiusSpinner,double numsSpinner) : base(width)
        {
            InitlizeImage();
            qutur = quturSpinner;
            radius = radiusSpinner;
            nums = numsSpinner;
        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 30, FontStyle.Regular);
            Brush b = Brushes.Red;
            g.DrawString("T : "+qutur, f, b, new PointF(0, 40));
            g.DrawString("n : "+nums, f, b, new PointF(200, 40));
            g.DrawString("r : "+radius, f, b, new PointF(400, 40));
            g.Dispose();
            return img;
        }
        public override double TotalLengthCm()
        {
            return width;
        }
        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/SpinnerLines.png");
        }
    }
}
