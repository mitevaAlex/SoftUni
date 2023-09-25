using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Madrid"));

            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("Sofia"));
        }
    }
}
