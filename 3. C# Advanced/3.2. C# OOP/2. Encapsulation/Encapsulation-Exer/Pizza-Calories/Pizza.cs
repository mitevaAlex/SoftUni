using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public int ToppingsCount => this.toppings.Count;

        public double Calories => this.Dough.Calories + this.toppings.Sum(x => x.Calories);

        public void AddTopping(string toppingName, int grams)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            Topping topping = new Topping(toppingName, grams);
            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }

    }
}
