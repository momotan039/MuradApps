using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    class RectangleMissOne : Rectangle
    {
        public RectangleMissOne(double width, double height) : base(width, height)
        {
        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 50, FontStyle.Bold);
            Brush b = Brushes.Red;
            g.DrawString(width + "", f, b, new PointF(300, 20));
            g.DrawString(height + "", f, b, new PointF(40, 170));
            g.Dispose();
            return img;
        }
        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/RectangleMissOne.png");
        }
        public override double TotalLengthCm()
        {
            return base.TotalLengthCm() -height;
        }
    }

}
