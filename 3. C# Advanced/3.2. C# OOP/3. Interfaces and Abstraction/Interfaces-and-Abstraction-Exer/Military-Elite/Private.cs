using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {this.Salary:F2}";
        }
    }
}
