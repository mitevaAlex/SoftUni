using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal exchangeNeeded = decimal.Parse(Console.ReadLine()) * 100;
            int currentExchange = 0;
            int coinsCount = 0;

            while (currentExchange < exchangeNeeded)
            {
                if (currentExchange + 200 <= exchangeNeeded)
                {
                    currentExchange += 200;
                    coinsCount++;
                }
                else if (currentExchange + 100 <= exchangeNeeded)
                {
                    currentExchange += 100;
                    coinsCount++;
                }
                else if (currentExchange + 50 <= exchangeNeeded)
                {
                    currentExchange += 50;
                    coinsCount++;
                }
                else if (currentExchange + 20 <= exchangeNeeded)
                {
                    currentExchange += 20;
                    coinsCount++;
                }
                else if (currentExchange + 10 <= exchangeNeeded)
                {
                    currentExchange += 10;
                    coinsCount++;
                }
                else if (currentExchange + 5 <= exchangeNeeded)
                {
                    currentExchange += 5;
                    coinsCount++;
                }
                else if (currentExchange + 2 <= exchangeNeeded)
                {
                    currentExchange += 2;
                    coinsCount++;
                }
                else if (currentExchange + 1 <= exchangeNeeded)
                {
                    currentExchange += 1;
                    coinsCount++;
                }
            }
            Console.WriteLine(coinsCount);
        }
    }
}
