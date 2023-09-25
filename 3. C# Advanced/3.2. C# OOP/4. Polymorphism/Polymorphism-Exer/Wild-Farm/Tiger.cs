using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<string> AllowedFoods => new List<string> { "Meat" };

        protected override double WeightIncrease => 1;

        public override void ShowHungry()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
