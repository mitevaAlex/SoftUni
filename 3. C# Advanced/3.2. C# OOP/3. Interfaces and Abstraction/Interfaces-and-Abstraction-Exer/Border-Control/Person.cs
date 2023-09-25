using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Person : ICitizen
    {
        public Person(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

    }
}
