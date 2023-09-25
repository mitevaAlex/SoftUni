using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override List<string> AllowedFoods => new List<string> {"Meat"};

        protected override double WeightIncrease => 0.25;

        public override void ShowHungry()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
