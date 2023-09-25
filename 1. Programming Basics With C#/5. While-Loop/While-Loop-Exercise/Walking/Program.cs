using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            int totalSteps = 0;
            int goal = 10000;

            while (totalSteps < goal)
            {
                command = Console.ReadLine();
                if (command == "Going home")
                {
                    totalSteps += int.Parse(Console.ReadLine());
                    break;
                }
                else
                {
                    totalSteps += int.Parse(command);
                }

            }
            int stepsLeft = goal - totalSteps;
            if (totalSteps >= goal)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{stepsLeft} more steps to reach goal.");
            }
        }
    }
}
