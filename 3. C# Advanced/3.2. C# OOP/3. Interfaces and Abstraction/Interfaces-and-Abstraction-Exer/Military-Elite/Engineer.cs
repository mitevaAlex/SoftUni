using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_Elite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, params Repair[] repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs.ToList();
        }

        public List<Repair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            this.Repairs.ForEach(x => sb.AppendLine($"  {x}"));
            return sb.ToString().Trim();
        }
    }
}
