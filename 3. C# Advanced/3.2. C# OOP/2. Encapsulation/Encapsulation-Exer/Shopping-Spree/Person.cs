using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Products { get; private set; }

        public void Buy(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.Money -= product.Cost;
                this.Products.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} - ");
            if (this.Products.Count == 0)
            {
                sb.Append("Nothing bought");
            }
            else
            {
                sb.Append(string.Join(", ", this.Products));
            }
            return sb.ToString();
        }
    }
}
