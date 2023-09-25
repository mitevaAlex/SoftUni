using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }
        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"Name: {base.FirstName} {base.LastName} Id: {base.Id}{Environment.NewLine}Code Number: {this.CodeNumber}";
        }
    }
}
