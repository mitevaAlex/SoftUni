using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override List<string> AllowedFoods => new List<string> { "Vegetable", "Fruit", "Meat", "Seeds" };

        protected override double WeightIncrease => 0.35;

        public override void ShowHungry()
        {
            Console.WriteLine("Cluck");
        }
    }
}
