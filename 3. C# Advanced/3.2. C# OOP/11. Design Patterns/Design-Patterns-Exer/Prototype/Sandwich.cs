using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        private string GetIngredientList()
        {
            return $"{bread}, {meat}, {cheese}, {veggies}";
        }

        public override SandwichPrototype Clone()
        {
            string ingredientsList = this.GetIngredientList();
            Console.WriteLine($"Cloning sandwich with ingredients : {ingredientsList}");

            return this.MemberwiseClone() as SandwichPrototype;
        }
    }
}
