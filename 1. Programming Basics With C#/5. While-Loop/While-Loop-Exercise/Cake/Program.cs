using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int cakePieces = width * length;
            int piecesNeeded = 0;
            string command = string.Empty;

            while (piecesNeeded <= cakePieces)
            {
                command = Console.ReadLine();

                if (command == "STOP")
                {
                    break;
                }

                piecesNeeded += int.Parse(command);
            }
            int piecesLeft = Math.Abs(cakePieces - piecesNeeded);
            if (piecesNeeded <= cakePieces)
            {
                Console.WriteLine($"{piecesLeft} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {piecesLeft} pieces more.");
            }
        }
    }
}
