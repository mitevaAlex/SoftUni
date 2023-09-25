using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            Dictionary<string, string> cars = new Dictionary<string, string>();
            for (int i = 0; i < commandsCount; i++)
            {
                //"register {username} {licensePlateNumber}" or "unregister {username}"
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0]; 
                string user = commandArgs[1];
                if (operation == "register")
                {
                    if (DoesUserExist(cars, user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {cars[user]}");
                        continue;
                    }
                    cars.Add(user, commandArgs[2]);
                    Console.WriteLine($"{user} registered {commandArgs[2]} successfully");
                }
                else if (operation == "unregister")
                {
                    if (!DoesUserExist(cars, user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                        continue;
                    }
                    cars.Remove(user);
                    Console.WriteLine($"{user} unregistered successfully");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,
                cars.Select(x => $"{x.Key} => {x.Value}")));
        }

        static bool DoesUserExist(Dictionary<string, string> cars, string user)
        {
            return cars.ContainsKey(user);
        }
    }
}
