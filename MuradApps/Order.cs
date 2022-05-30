using System;
using System.Collections.Generic;
using System.Text;

namespace MuradApps
{
    internal class Order
    {
        public int id { get; set; }
        public int idItem { get; set; }

        virtual public ItemSql item { get; set; }
    }
}
