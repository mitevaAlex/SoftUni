using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override List<string> AllowedFoods => new List<string> {"Meat"};

        protected override double WeightIncrease => 0.4;

        public override void ShowHungry()
        {
            Console.WriteLine("Woof!");
        }
    }
}
