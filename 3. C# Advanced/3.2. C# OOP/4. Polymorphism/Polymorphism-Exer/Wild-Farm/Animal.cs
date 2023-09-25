using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        protected abstract List<string> AllowedFoods { get; }

        protected abstract double WeightIncrease { get; }

        public string Name { get; } 

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void ShowHungry();

        public void Eat(Food food)
        {
            if (AllowedFoods.Contains(food.GetType().Name))
            {
                FoodEaten += food.Quantity;
                Weight += WeightIncrease * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
