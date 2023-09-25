using System;

namespace Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                //"<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType>" 
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(int.Parse(carData[1]), int.Parse(carData[2]));
                Cargo cargo = new Cargo(int.Parse(carData[3]), carData[4]);
            }
        }
    }
}
