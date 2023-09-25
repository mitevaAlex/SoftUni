using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonDistances = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int removeIndex = 0;
            int removedDistancesSum = 0;
            while (pokemonDistances.Count > 0)
            {
                removeIndex = int.Parse(Console.ReadLine());
                int removedDistance = 0;
                if (removeIndex < 0)
                {
                    removeIndex = 0;
                    removedDistance = pokemonDistances[removeIndex];
                    pokemonDistances[removeIndex] = pokemonDistances[pokemonDistances.Count - 1];
                }
                else if (removeIndex >= pokemonDistances.Count)
                {
                    removeIndex = pokemonDistances.Count - 1;
                    removedDistance = pokemonDistances[removeIndex];
                    pokemonDistances[removeIndex] = pokemonDistances[0];
                }
                else
                {
                    removedDistance = pokemonDistances[removeIndex];
                    pokemonDistances.RemoveAt(removeIndex);
                }
                removedDistancesSum += removedDistance;
                ChangeDistances(pokemonDistances, removedDistance);               
            }
            Console.WriteLine(removedDistancesSum);
        }

        static void ChangeDistances(List<int> pokemonDistances, int removedDistance)
        {
            for (int i = 0; i < pokemonDistances.Count; i++)
            {
                int currentDistance = pokemonDistances[i];
                if (currentDistance <= removedDistance)
                {
                    pokemonDistances[i] += removedDistance;
                }
                else
                {
                    pokemonDistances[i] -= removedDistance;
                }
            }  
        }
    }
}
