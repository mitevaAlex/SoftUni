using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; protected set; }
    }
}
