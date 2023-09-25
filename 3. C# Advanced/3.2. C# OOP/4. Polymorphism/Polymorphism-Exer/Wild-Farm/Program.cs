using System;
using System.Collections.Generic;
using System.Linq;

namespace Wild_Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = "";
            for (int i = 0; (command = Console.ReadLine()) != "End"; i++)
            {
                if (i % 2 == 0)
                {
                    string[] animalArgs = command.Split(' ');
                    string type = animalArgs[0];
                    Animal animal = null;
                    switch (type)
                    {
                        case "Owl":
                            animal = new Owl(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3]));
                            break;
                        case "Hen":
                            animal = new Hen(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3]));
                            break;
                        case "Mouse":
                            animal = new Mouse(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]);
                            break;
                        case "Dog":
                            animal = new Dog(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]);
                            break;
                        case "Cat":
                            animal = new Cat(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]);
                            break;
                        case "Tiger":
                            animal = new Tiger(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]);
                            break;
                    }

                    animals.Add(animal);
                }
                else
                {
                    string[] foodArgs = command.Split(' ');
                    string type = foodArgs[0];
                    int quantity = int.Parse(foodArgs[1]);
                    Food food = null;
                    switch (type)
                    {
                        case "Vegetable":
                            food = new Vegetable(quantity);
                            break;
                        case "Fruit":
                            food = new Fruit(quantity);
                            break;
                        case "Meat":
                            food = new Meat(quantity);
                            break;
                        case "Seeds":
                            food = new Seeds(quantity);
                            break;
                    }

                    animals.Last().ShowHungry();
                    animals.Last().Eat(food);
                }

            }

            animals.ForEach(x => Console.WriteLine(x));
        }
    }
}
