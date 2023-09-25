using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int boxesCount = 0;
            int cubicMetresBoxes = 0;
            int cubicMetresSpace = width * length * height;

            while (cubicMetresBoxes <= cubicMetresSpace)
            {
                command = Console.ReadLine();
                if (command == "Done")
                {
                    break;
                }
                else
                {
                    boxesCount = int.Parse(command);
                    cubicMetresBoxes += boxesCount * 1;
                }
            }
            int spaceLeftOrNeeded = Math.Abs(cubicMetresSpace - cubicMetresBoxes);

            if (command == "Done")
            {
                Console.WriteLine($"{spaceLeftOrNeeded} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {spaceLeftOrNeeded} Cubic meters more.");
            }
        }
    }
}
