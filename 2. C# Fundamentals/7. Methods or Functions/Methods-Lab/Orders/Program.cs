using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            FindTotalPrice(product, quantity);
        }

        static void FindTotalPrice(string product, int quantity)
        {
            double productPrice = 0.0;

            switch (product)
            {
                case "coffee":
                    productPrice = 1.5;
                    break;
                case "coke":
                    productPrice = 1.4;
                    break;
                case "water":
                    productPrice = 1;
                    break;
                case "snacks":
                    productPrice = 2;
                    break;
            }

            double totalPrice = quantity * productPrice;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
