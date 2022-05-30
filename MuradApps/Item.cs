using System;
using System.Collections.Generic;
using System.Text;

namespace MuradApps
{
    internal class Item
    {
        public string qutur { get; set; }
        public string weight { get; set; }
        public string totalm { get; set; }
        public string nums { get; set; }
        public string nameShape { get; set; } 
        public int id { get; set; }

        public static int ID = 100;
        public Shape shape { get; set; }
    }
}
