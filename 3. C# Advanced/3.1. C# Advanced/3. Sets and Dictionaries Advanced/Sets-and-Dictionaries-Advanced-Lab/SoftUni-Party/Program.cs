using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> guestList = new Dictionary<string, HashSet<string>>();
            guestList.Add("VIP", new HashSet<string>());
            guestList.Add("regular", new HashSet<string>());
            string command = "";
            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(command[0]))
                {
                    guestList["VIP"].Add(command);
                }
                else
                {
                    guestList["regular"].Add(command);
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                guestList["VIP"].Remove(command);
                guestList["regular"].Remove(command);
            }

            Console.WriteLine(guestList["VIP"].Count + guestList["regular"].Count);
            if (guestList["VIP"].Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guestList["VIP"]));
            }

            if (guestList["regular"].Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guestList["regular"]));
            }
        }
    }
}
