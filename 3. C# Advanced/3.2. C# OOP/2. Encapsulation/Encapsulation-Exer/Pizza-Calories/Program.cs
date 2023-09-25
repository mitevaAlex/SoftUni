using System;

namespace Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = new Pizza(Console.ReadLine()
                    .Split(' ')[1]);
                string[] doughData = Console.ReadLine()
                    .Split(' ');
                Dough dough = new Dough(doughData[1], doughData[2], int.Parse(doughData[3]));
                pizza.Dough = dough;
                string command = "";
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingData = command
                        .Split(' ');
                    pizza.AddTopping(toppingData[1], int.Parse(toppingData[2]));
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
