using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> es = new EqualityScale<string>("alex", "alex");
            Console.WriteLine(es.AreEqual());
        }
    }
}
