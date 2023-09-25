using System;
using System.Collections.Generic;
using System.Linq;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string resource = string.Empty;
            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, 0);
                }
                resources[resource] += quantity;
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                resources.Select(x => $"{x.Key} -> {x.Value}")));
        }
    }
}
