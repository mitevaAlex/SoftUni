using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            //stores demons' names(string), health and damage
            Dictionary<string, Demon> demons = Console.ReadLine()
                .Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => new Demon());
            foreach (var demon in demons)
            {
                demon.Value.Health = Regex
                    .Matches(demon.Key, @"[^\d+\-*\/.]")
                    .Select(x => (int)char.Parse(x.Value))
                    .Sum();
                decimal damage = (decimal)Regex
                    .Matches(demon.Key, @"(\+|-)?\d+\.?\d*")
                    .Select(x => decimal.Parse(x.Value))
                    .Sum();
                MatchCollection operations = Regex.Matches(demon.Key, @"(\/|\*)");//stores
                //operations' order (operations: "*" or "/" which mean multiplication by 2 or division by 2)
                foreach (Match operation in operations)
                {
                    if (operation.Value == "*")
                        damage *= 2;
                    else
                        damage /= 2;
                }
                demon.Value.Damage = damage;
            }
            demons = demons
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine(string.Join(Environment.NewLine,
                demons.Select(x => $"{x.Key} - {x.Value.Health} health, {x.Value.Damage:F2} damage")));
        }
    }
}
