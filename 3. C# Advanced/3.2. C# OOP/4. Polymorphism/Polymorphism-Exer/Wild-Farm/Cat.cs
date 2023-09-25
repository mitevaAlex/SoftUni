using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<string> AllowedFoods => new List<string> { "Vegetable", "Meat" };

        protected override double WeightIncrease => 0.3;

        public override void ShowHungry()
        {
            Console.WriteLine("Meow");
        }
    }
}
