using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMillilitres = 50;
        private const decimal CoffeePrice = 3.5M;

        public Coffee(string name, double caffeine)
            : base(name, CoffeePrice, CoffeeMillilitres)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
