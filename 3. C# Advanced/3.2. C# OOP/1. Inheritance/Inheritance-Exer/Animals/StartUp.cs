using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = "";
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string animalType = command;
                string[] data = Console.ReadLine()
                    .Split(' ');
                try
                {
                    Animal animal = null;
                    switch (animalType)
                    {
                        case "Dog":
                            animal = new Dog(data[0], int.Parse(data[1]), data[2]);
                            break;
                        case "Cat":
                            animal = new Cat(data[0], int.Parse(data[1]), data[2]);
                            break;
                        case "Frog":
                            animal = new Frog(data[0], int.Parse(data[1]), data[2]);
                            break;
                        case "Kitten":
                            animal = new Kitten(data[0], int.Parse(data[1]));
                            break;
                        case "Tomcat":
                            animal = new Tomcat(data[0], int.Parse(data[1]));
                            break;
                    }

                    animals.Add(animal);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
               
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
