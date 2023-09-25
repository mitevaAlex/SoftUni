using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "buy")
            {
                //"{name} {price} {quantity}"
                string[] productData = command
                    .Split(' ');
                Product product = new Product(productData[0],
                    double.Parse(productData[1]), int.Parse(productData[2]));
                if (!products.ContainsKey(product.Name))
                {
                    products.Add(product.Name, product);
                }
                else
                {
                    products[product.Name].Quantity += product.Quantity;
                    products[product.Name].Price = product.Price;
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                products.Select(x => $"{x.Key} -> {x.Value.Price * x.Value.Quantity:F2}")));
        }
    }
}
