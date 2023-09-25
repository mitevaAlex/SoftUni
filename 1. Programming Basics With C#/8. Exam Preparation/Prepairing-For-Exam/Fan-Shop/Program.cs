using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fan_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int itemsCount = int.Parse(Console.ReadLine());
            int totalPrice = 0;

            for (int i = 0; i < itemsCount; i++)
            {
                string item = Console.ReadLine();
                if (item == "hoodie")
                {
                    totalPrice += 30;
                }
                else if (item == "keychain")
                {
                    totalPrice += 4;
                }
                else if (item == "T-shirt")
                {
                    totalPrice += 20;
                }
                else if (item == "flag")
                {
                    totalPrice += 15;
                }
                else if (item == "sticker")
                {
                    totalPrice += 1;
                }
            }
            int moneyLeftOrNeeded = Math.Abs(budget - totalPrice);

            if (budget >= totalPrice)
            {
                Console.WriteLine($"You bought {itemsCount} items and left with {moneyLeftOrNeeded} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {moneyLeftOrNeeded} more lv.");
            }
        }
    }
}
