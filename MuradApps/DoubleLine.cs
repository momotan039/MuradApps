using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    class DoubleLine : Line
    {
        public double height { get; set; }
        public PointF pHeight { get; set; }
        public DoubleLine(double width, double height) : base(width)
        {
            this.height = height;
        }
        public override Image CustomizeImage()
        {
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("tahoma", 70, FontStyle.Bold);
            Brush b = Brushes.Red;
            g.DrawString(width + "", f, b, new PointF(300, 150));
            g.DrawString(height + "", f, b, new PointF(50, 40));
            g.Dispose();
            return img;
        }
        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/DoubleLine.png");
        }
    }

}
