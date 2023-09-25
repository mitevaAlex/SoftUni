using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] person1Data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string person1Name = $"{person1Data[0]} {person1Data[1]}";
            string address = person1Data[2];
            CustomTuple<string, string> person = new CustomTuple<string, string>(person1Name, address);
            Console.WriteLine(person);

            string[] person2Data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string person2name = person2Data[0];
            int beerLitres = int.Parse(person2Data[1]);
            CustomTuple<string, int> personAndBeer = new CustomTuple<string, int>(person2name, beerLitres);
            Console.WriteLine(personAndBeer);

            double[] numbersData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            CustomTuple<int, double> numbers = new CustomTuple<int, double>((int)numbersData[0], numbersData[1]);
            Console.WriteLine(numbers);
        }
    }
}
