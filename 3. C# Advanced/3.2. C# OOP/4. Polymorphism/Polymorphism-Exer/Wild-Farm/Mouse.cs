using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightIncrease => 0.1;

        protected override List<string> AllowedFoods => new List<string> { "Vegetable", "Fruit" };

        public override void ShowHungry()
        {
            Console.WriteLine("Squeak");
        }
    }
}
