using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private Dictionary<string, int> capitalsPopulations = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            string[] elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                capitalsPopulations.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string capitalName)
        {
            return capitalsPopulations[capitalName];
        }
    }
}
