using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayerEggsCount = int.Parse(Console.ReadLine());
            int secondPlayerEggsCount = int.Parse(Console.ReadLine());
            bool firstPlayerOutOfEggs = false;
            bool secondPlayerOutOfEggs = false;

            string command = Console.ReadLine();
            while (command != "End of battle")
            {
                if (firstPlayerEggsCount == 0)
                {
                    firstPlayerOutOfEggs = true;
                    break;
                }
                else if (secondPlayerEggsCount == 0)
                {
                    secondPlayerOutOfEggs = true;
                    break;
                }

                if (command == "one")
                {
                    secondPlayerEggsCount--;
                }
                else if(command == "two")
                {
                    firstPlayerEggsCount--;   
                }

                if (firstPlayerEggsCount >0 && secondPlayerEggsCount >0)
                {
                    command = Console.ReadLine();
                }
            }

            if (firstPlayerOutOfEggs)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {secondPlayerEggsCount} eggs left.");
            }
            else if (secondPlayerOutOfEggs)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayerEggsCount} eggs left.");
            }
            else if (command == "End of battle")
            {
                Console.WriteLine($"Player one has {firstPlayerEggsCount} eggs left.");
                Console.WriteLine($"Player two has {secondPlayerEggsCount} eggs left.");
            }   
        }
    }
}
