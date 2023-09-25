using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int moneyForSinger = int.Parse(Console.ReadLine());
            int guests = 0;
            int incomeMoney = 0;
            string command = Console.ReadLine();

            while (command != "The restaurant is full")
            {
                int currentGroupGuestsCount = int.Parse(command);

                if (currentGroupGuestsCount < 5)
                {
                    incomeMoney += currentGroupGuestsCount * 100;
                }
                else
                {
                    incomeMoney += currentGroupGuestsCount * 70;
                }
                guests += currentGroupGuestsCount;
                command = Console.ReadLine();
            }

            if (incomeMoney >= moneyForSinger)
            {
                int moneyLeft = incomeMoney - moneyForSinger;
                Console.WriteLine($"You have {guests} guests and {moneyLeft} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {guests} guests and {incomeMoney} leva income, but no singer.");
            }

        }
    }
}
