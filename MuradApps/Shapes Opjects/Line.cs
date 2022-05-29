using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    class Line : Shape
    {
        public Line(double width)
            : base(width)
        {
            InitlizeImage();
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

        public override double Total()
        {
            return width;
        }


        protected override void InitlizeImage()
        {
            this.img = Image.FromFile(@"../../../images/Line.png");
        }
    }

}
