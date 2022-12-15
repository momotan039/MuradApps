using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    class RectangleMissOneWithTails : RectangleMissOne
    {
        public double tails { get; set; }
        public RectangleMissOneWithTails(double width, double height, double tails)
            : base(width, height)
        {
            this.tails = tails;
        }
        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/RectangleMissOneWithTails.png");

        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 90, FontStyle.Bold);
            Brush b = Brushes.Red;
            g.DrawString(width + "", f, b, new PointF(550, 100));
            g.DrawString(height + "", f, b, new PointF(360, 300));
            g.DrawString(tails + "", f, b, new PointF(100, 650));
            g.Dispose();
            return img;
        }
        public override double TotalLengthCm()
        {
            return base.TotalLengthCm() +height-width+(tails*2);
        }
    }

}
