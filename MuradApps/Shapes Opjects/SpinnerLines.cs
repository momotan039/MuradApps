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

        public SpinnerLines(double width,double quturSpinner, double radiusSpinner) : base(width)
        {
            InitlizeImage();
            this.qutur = quturSpinner;
            this.radius = radiusSpinner;
        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 70, FontStyle.Bold);
            Brush b = Brushes.Red;
            g.DrawString(width + "", f, b, new PointF(300, 40));
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
