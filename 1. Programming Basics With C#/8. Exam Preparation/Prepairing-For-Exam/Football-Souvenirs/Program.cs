using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();//"Argentina", "Brazil", "Croatia", "Denmark";
            string typeSouvenirs = Console.ReadLine();//"flags", "caps", "posters", "stickers"
            int souvenirsCount = int.Parse(Console.ReadLine());
            double totalPrice = 0.0;

            if (team == "Argentina")
            {
                if (typeSouvenirs == "flags")
                {
                    totalPrice += 3.25 * souvenirsCount;
                }
                else if (typeSouvenirs == "caps")
                {
                    totalPrice += 7.2 * souvenirsCount;
                }
                else if (typeSouvenirs == "posters")
                {
                    totalPrice += 5.1 * souvenirsCount;
                }
                else if (typeSouvenirs == "stickers")
                {
                    totalPrice += 1.25 * souvenirsCount;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else if (team == "Brazil")
            {
                if (typeSouvenirs == "flags")
                {
                    totalPrice += 4.2 * souvenirsCount;
                }
                else if (typeSouvenirs == "caps")
                {
                    totalPrice += 8.5 * souvenirsCount;
                }
                else if (typeSouvenirs == "posters")
                {
                    totalPrice += 5.35 * souvenirsCount;
                }
                else if (typeSouvenirs == "stickers")
                {
                    totalPrice += 1.2 * souvenirsCount;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else if (team == "Croatia")
            {
                if (typeSouvenirs == "flags")
                {
                    totalPrice += 2.75 * souvenirsCount;
                }
                else if (typeSouvenirs == "caps")
                {
                    totalPrice += 6.9 * souvenirsCount;
                }
                else if (typeSouvenirs == "posters")
                {
                    totalPrice += 4.95 * souvenirsCount;
                }
                else if (typeSouvenirs == "stickers")
                {
                    totalPrice += 1.1 * souvenirsCount;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else if (team == "Denmark")
            {
                if (typeSouvenirs == "flags")
                {
                    totalPrice += 3.1 * souvenirsCount;
                }
                else if (typeSouvenirs == "caps")
                {
                    totalPrice += 6.5 * souvenirsCount;
                }
                else if (typeSouvenirs == "posters")
                {
                    totalPrice += 4.8 * souvenirsCount;
                }
                else if (typeSouvenirs == "stickers")
                {
                    totalPrice += 0.9 * souvenirsCount;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid country!");
                return;
            }

            Console.WriteLine($"Pepi bought {souvenirsCount} {typeSouvenirs} of {team} for {totalPrice:F2} lv.");
        }
    }
}
