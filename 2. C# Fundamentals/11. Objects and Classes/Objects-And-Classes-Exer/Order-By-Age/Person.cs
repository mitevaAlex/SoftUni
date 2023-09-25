using System;
using System.Collections.Generic;
using System.Text;

namespace Order_By_Age
{
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Person(string name, string ID, int age)
        {
            this.Name = name;
            this.ID = ID;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}
