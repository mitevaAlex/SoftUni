using System;
using System.Linq;

namespace Threeuple
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            string[] person1Data = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string person1Name = $"{person1Data[0]} {person1Data[1]}";
            string address = person1Data[2];
            string town = string.Join(' ', person1Data.Skip(3));
            Threeuple<string, string, string> person = new Threeuple<string, string, string>(person1Name, address, town);
            Console.WriteLine(person);

            string[] person2Data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string person2name = person2Data[0];
            int beerLitres = int.Parse(person2Data[1]);
            bool drunk = person2Data[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> personAndBeer = new Threeuple<string, int, bool>(person2name, beerLitres, drunk);
            Console.WriteLine(personAndBeer);

            string[] person3Data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string person3name = person3Data[0];
            double accountBalance = Math.Round(double.Parse(person3Data[1]), 1);
            string bankName = person3Data[2];
            Threeuple<string, double, string> personBankData = new Threeuple<string, double, string>(person3name, accountBalance, bankName);
            Console.WriteLine(personBankData);
        }
    }
}
