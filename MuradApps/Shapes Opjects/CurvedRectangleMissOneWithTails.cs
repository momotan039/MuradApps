using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    class CurvedRectangleMissOneWithTails : RectangleMissOneWithTails
    {
        public CurvedRectangleMissOneWithTails(double width, double height, double tails) : base(width, height, tails)
        {
        }
        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/CurvedRectangleMissOneWithTails.png");

        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 50, FontStyle.Bold);
            Brush b = Brushes.Red;
            g.DrawString(width + "", f, b, new PointF(500, -10));
            g.DrawString(height + "", f, b, new PointF(320, 180));
            g.DrawString(tails + "", f, b, new PointF(850, 180));
            g.Dispose();
            return img;
        }
        public override double TotalLengthCm()
        {
            return base.TotalLengthCm();
        }

    }

}
