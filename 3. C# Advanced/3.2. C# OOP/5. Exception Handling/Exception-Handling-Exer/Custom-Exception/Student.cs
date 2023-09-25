using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom_Exception
{
    public class Student
    {
        private string name;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (!value.All(x => char.IsLetter(x)))
                {
                    throw new InvalidPersonNameException();
                }

                name = value; 
            }
        }

        public string Email { get; private set; }
    }
}
