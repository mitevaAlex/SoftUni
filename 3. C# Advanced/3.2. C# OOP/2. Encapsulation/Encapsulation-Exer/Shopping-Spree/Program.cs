using System;
using System.Collections.Generic;

namespace Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                for (int i = 0; i < peopleInfo.Length; i++)
                {
                    string[] personInfo = peopleInfo[i]
                        .Split('=');
                    Person person = new Person(personInfo[0], double.Parse(personInfo[1]));
                    people.Add(person);
                }

                for (int i = 0; i < productsInfo.Length; i++)
                {
                    string[] productInfo = productsInfo[i]
                        .Split('=');
                    Product product = new Product(productInfo[0], double.Parse(productInfo[1]));
                    products.Add(product);
                }

                string command = "";
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    people[people.FindIndex(x => x.Name == commandArgs[0])].Buy(products[products.FindIndex(x => x.Name == commandArgs[1])]);
                }

                people.ForEach(x => Console.WriteLine(x));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
