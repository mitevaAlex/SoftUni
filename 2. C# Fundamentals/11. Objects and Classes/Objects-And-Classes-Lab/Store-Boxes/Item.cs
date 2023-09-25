using System;
using System.Collections.Generic;
using System.Text;

namespace Store_Boxes
{
    class Item
    {
        public  string Name { get; set; }
        public  double Price { get; set; }

        public Item(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
