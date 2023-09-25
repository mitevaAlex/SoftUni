using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories
{
    public class Topping
    {
        private const double BaseCalories = 2;
        private const double MeatCalories = 1.2;
        private const double VeggiesCalories = 0.8;
        private const double CheeseCalories = 1.1;
        private const double SauceCalories = 0.9;

        private string type;
        private int weight;//grams

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get { return this.type; }
            set
            {
                string input = value.ToUpper();
                if (input != "MEAT" && input != "VEGGIES" && input != "CHEESE" && input != "SAUCE")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        private int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double result = BaseCalories;
                switch (this.Type.ToUpper())
                {
                    case "MEAT":
                        result *= MeatCalories;
                        break;
                    case "VEGGIES":
                        result *= VeggiesCalories;
                        break;
                    case "CHEESE":
                        result *= CheeseCalories;
                        break;
                    case "SAUCE":
                        result *= SauceCalories;
                        break;
                }

                return result * this.Weight;
            }
        }

        public override string ToString()
        {
            return $"{this.Calories:F2}";
        }
    }
}
