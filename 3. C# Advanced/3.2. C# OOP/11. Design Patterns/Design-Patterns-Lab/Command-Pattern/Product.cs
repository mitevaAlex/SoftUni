using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Pattern
{
    public class Product
    {
        public string Name { get; private set; }

        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(int amount)
        {
            Price += amount;
            Console.WriteLine($"The price for the {Name} hase been increased by {amount}$.");
        }

        public void DecreasePrice(int amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price for the {Name} hase been decreased by {amount}$.");
            }
        }

        public override string ToString()
        {
            return $"Current price for the {Name} product is {Price}$.";
        }
    }
}
