using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MuradApps
{
    internal abstract class Shape
    {
        public double width { get; set; }
        public PointF pWidth { get; set; }
        protected Image img { get; set; }
        public Shape(double width)
        {
            this.width = width;
        }
        protected abstract void InitlizeImage();
        
        public abstract Image CustomizeImage();
        public abstract double Total();
    }
    
   


    
}
