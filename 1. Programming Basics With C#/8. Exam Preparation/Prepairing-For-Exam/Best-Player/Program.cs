using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string bestPlayer = string.Empty;
            int bestGoals = 0;

            while ((name = Console.ReadLine()) != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if (goals > bestGoals)
                {
                    bestPlayer = name;
                    bestGoals = goals;
                }

                if (goals >= 10)
                {
                    break;
                }
            }

            Console.WriteLine($"{bestPlayer} is the best player!");
            if (bestGoals >= 3)
            {
                Console.WriteLine($"He has scored {bestGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestGoals} goals.");
            }
            
        }
    }
}
