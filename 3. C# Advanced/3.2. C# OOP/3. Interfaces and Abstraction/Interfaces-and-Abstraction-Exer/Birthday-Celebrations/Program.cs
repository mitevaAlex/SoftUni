using System;
using System.Collections.Generic;

namespace Birthday_Celebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAliveCitizen> aliveCitizens = new List<IAliveCitizen>();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] citizenArgs = command
                    .Split(' ');
                string citizenType = citizenArgs[0];
                IAliveCitizen aliveCitizen = null;
                switch (citizenType)
                {
                    case "Citizen":
                        aliveCitizen = new Person(citizenArgs[1], int.Parse(citizenArgs[2]), citizenArgs[3], citizenArgs[4]);
                        aliveCitizens.Add(aliveCitizen);
                        break;
                    case "Pet":
                        aliveCitizen = new Pet(citizenArgs[1], citizenArgs[2]);
                        aliveCitizens.Add(aliveCitizen);
                        break;
                }
            }

            string wantedBirthYear = Console.ReadLine();
            foreach (IAliveCitizen aliveCitizen in aliveCitizens)
            {
                if (aliveCitizen.Birthdate.EndsWith(wantedBirthYear))
                {
                    Console.WriteLine(aliveCitizen.Birthdate);
                }
            }
        }
    }
}
