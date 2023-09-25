using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int stadiumName = 'B'; stadiumName <= 'L'; stadiumName += 2)
            {
                for (int sectorName = 'f'; sectorName >= 'a'; sectorName--)
                {
                    for (int entry = 'A'; entry <= 'C'; entry++)
                    {
                        for (int row = 1; row <= 10; row++)
                        {
                            for (int seat = 10; seat >= 1; seat--)
                            {
                                counter++;
                                if (counter == number)
                                {
                                    int prize = stadiumName + sectorName + entry + row + seat;
                                    string ticketCombination = $"{(char)stadiumName}{(char)sectorName}{(char)entry}{row}{seat}";
                                    Console.WriteLine($"Ticket combination: {ticketCombination}");
                                    Console.WriteLine($"Prize: {prize} lv.");
                                }                               
                            }
                        }
                    }
                }
            }
        }
    }
}
