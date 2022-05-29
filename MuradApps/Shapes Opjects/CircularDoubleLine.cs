using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    class CircularDoubleLine : DoubleLine
    {
        public CircularDoubleLine(double width, double height) : base(width, height)
        {
        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 50, FontStyle.Bold);
            Brush b = Brushes.Red;
            g.DrawString(width + "", f, b, new PointF(500, 50));
            g.DrawString(width + "", f, b, new PointF(500, 380));
            g.DrawString(height + "", f, b, new PointF(-15, 250));
            g.Dispose();
            return img;
        }
        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/CircularDoubleLine.png");
        }
        public override double TotalLengthCm()
        {
            return base.TotalLengthCm()+width;
        }
    }
}
