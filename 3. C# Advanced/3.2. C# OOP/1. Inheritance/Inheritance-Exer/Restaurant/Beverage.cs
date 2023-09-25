using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double millilitres)
            : base(name, price)
        {
            this.Millilitres = millilitres;
        }

        public double Millilitres { get; set; }
    }
}
