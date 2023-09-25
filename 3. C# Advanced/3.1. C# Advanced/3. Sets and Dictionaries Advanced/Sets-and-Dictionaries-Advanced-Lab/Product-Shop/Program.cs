using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopsData = new SortedDictionary<string, Dictionary<string, double>>();
            string command = "";
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] currentShop = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = currentShop[0];
                string product = currentShop[1];
                double price = double.Parse(currentShop[2]);
                if (!shopsData.ContainsKey(shop))
                {
                    shopsData.Add(shop, new Dictionary<string, double>());
                }

                if (!shopsData[shop].ContainsKey(product))
                {
                    shopsData[shop].Add(product, 0);
                }

                shopsData[shop][product] = price;
            }


            foreach (var shop in shopsData)
            {
                Console.WriteLine($"{shop.Key}->{Environment.NewLine}{string.Join(Environment.NewLine, shop.Value.Select(x => $"Product: {x.Key}, Price: {x.Value}"))}");
            }
        }
    }
}
