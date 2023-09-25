using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Shortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            for (int i = 0; i < peopleCount; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(' ');
                IBuyer buyer = null;
                if (personArgs.Length == 4)
                {
                    buyer = new Citizen(personArgs[0], int.Parse(personArgs[1]), personArgs[2], personArgs[3]);
                }
                else if (personArgs.Length == 3)
                {
                    buyer = new Rebel(personArgs[0], int.Parse(personArgs[1]), personArgs[2]);
                }

                buyers.Add(personArgs[0], buyer);
            }

            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                if (buyers.ContainsKey(command))
                {
                    buyers[command].BuyFood();
                }
            }

            Console.WriteLine(buyers.Values.Sum(x => x.Food));
        }
    }
}
