using System;
using System.Collections.Generic;
using System.Text;

namespace Company_Roster
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Salary:F2}";
        }
    }
}
