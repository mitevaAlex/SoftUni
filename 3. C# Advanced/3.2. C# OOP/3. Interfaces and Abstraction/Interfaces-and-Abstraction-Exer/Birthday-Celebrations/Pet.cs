using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public class Pet : IAliveCitizen
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
