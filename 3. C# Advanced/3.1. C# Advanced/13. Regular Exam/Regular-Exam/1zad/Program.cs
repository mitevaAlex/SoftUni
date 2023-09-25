using System;
using System.Collections.Generic;
using System.Linq;

namespace _1zad
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(ReadInts());
            Stack<int> freshness = new Stack<int>(ReadInts());
            List<int> neededFreshness = new List<int>() { 150, 250, 300, 400 };
            Dictionary<string, int> dishesMade = new Dictionary<string, int>();
            dishesMade.Add("Chocolate cake", 0);
            dishesMade.Add("Dipping sauce", 0);
            dishesMade.Add("Green salad", 0);
            dishesMade.Add("Lobster", 0);

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int result = ingredients.Peek() * freshness.Peek();
                if (neededFreshness.Contains(result))
                {
                    switch (result)
                    {
                        case 150:
                            dishesMade["Dipping sauce"]++;
                            break;
                        case 250:
                            dishesMade["Green salad"]++;
                            break;
                        case 300:
                            dishesMade["Chocolate cake"]++;
                            break;
                        case 400:
                            dishesMade["Lobster"]++;
                            break;
                    }
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            if (dishesMade.All(x => x.Value >= 1))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishesMade)
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }

        static IEnumerable<int> ReadInts()
        {
            return Console.ReadLine()
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse);
        }
    }
}
