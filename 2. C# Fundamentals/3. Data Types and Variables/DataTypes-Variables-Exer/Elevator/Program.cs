using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());//the people who are going to use the elevator
            int peopleCapacity = int.Parse(Console.ReadLine());
            int elevatorCoursesCount = peopleCount / peopleCapacity;
            if (peopleCount % peopleCapacity != 0)
            {
                elevatorCoursesCount++;
            }
            Console.WriteLine(elevatorCoursesCount);
        }
    }
}
