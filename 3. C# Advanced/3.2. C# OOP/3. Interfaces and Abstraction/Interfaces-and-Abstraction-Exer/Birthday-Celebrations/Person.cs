using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{ 
    public class Person : ICitizen, IAliveCitizen
    {
        public Person(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
