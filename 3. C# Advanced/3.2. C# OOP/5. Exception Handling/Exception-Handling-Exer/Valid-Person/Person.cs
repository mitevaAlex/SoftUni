using System;
using System.Collections.Generic;
using System.Text;

namespace Valid_Person
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "The first name cannot be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "The last name cannot be null or empty.");
                }

                this.lastName = value;
            }
        }


        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in the range [0 ... 120].");
                }

                this.age = value;
            }
        }
    }
}
