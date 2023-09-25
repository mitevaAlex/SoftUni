using System;

namespace Explicit_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = ""; 
            while((command = Console.ReadLine()) != "End")
            {
                string[] citizenArgs = command
                    .Split(' ');
                Citizen citizen = new Citizen(citizenArgs[0], citizenArgs[1], int.Parse(citizenArgs[2]));
                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());
            }
        }
    }
}
