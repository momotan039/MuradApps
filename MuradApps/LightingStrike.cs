using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    class LightingStrike : Line
    {
        public double curvedHeight { get; set; }
        public LightingStrike(double width, double curvedHeight) : base(width)
        {
            this.curvedHeight = curvedHeight;
        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 48, FontStyle.Bold);
            Brush b = Brushes.Red;
            g.DrawString(width + "", f, b, new PointF(100, 20));
            g.DrawString(curvedHeight + "", f, b, new PointF(300, 40));
            g.DrawString(width + "", f, b, new PointF(500, 130));
            g.Dispose();
            return img;
        }

        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/LightingStrike.png");
        }
    }
}
