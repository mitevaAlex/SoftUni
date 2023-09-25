using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICitizen> citizens = new List<ICitizen>();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] citizenArgs = command
                    .Split(' ');
                ICitizen citizen = null;
                if (citizenArgs.Length == 2)
                {
                    citizen = new Robot(citizenArgs[0], citizenArgs[1]);
                }
                else if (citizenArgs.Length == 3)
                {
                    citizen = new Person(citizenArgs[0], int.Parse(citizenArgs[1]), citizenArgs[2]);
                }

                citizens.Add(citizen);
            }

            string fakeIdToken = Console.ReadLine();
            foreach (ICitizen citizen in citizens)
            {
                if (citizen.Id.EndsWith(fakeIdToken))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
