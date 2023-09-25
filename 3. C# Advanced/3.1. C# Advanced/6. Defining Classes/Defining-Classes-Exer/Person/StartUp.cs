using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person
            {
                Name = "Pesho",
                Age = 20
            };

            Person person2 = new Person
            {
                Name = "Gosho",
                Age = 18
            };

            Person person3 = new Person();
            person3.Name = "Stamat";
            person3.Age = 43;
        }
    }
}
