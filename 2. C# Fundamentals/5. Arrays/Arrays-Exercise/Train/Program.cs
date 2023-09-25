using System;
using System.Linq;
namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());

            int[] wagonPeopleCount = new int[wagonsCount];//the count of people in each wagon

            for (int currentWagon = 0; currentWagon < wagonsCount; currentWagon++)
            {
                wagonPeopleCount[currentWagon] = int.Parse(Console.ReadLine());
            }

            int totalPeople = wagonPeopleCount.Sum();
            Console.WriteLine(string.Join(' ', wagonPeopleCount));
            Console.WriteLine(totalPeople);
        }
    }
}
