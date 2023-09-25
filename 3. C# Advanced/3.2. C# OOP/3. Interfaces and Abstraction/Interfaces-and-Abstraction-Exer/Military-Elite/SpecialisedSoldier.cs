using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            if (corps != "Airforces" && corps != "Marines")
            {
                throw new ArgumentException("Invalid corps");
            }

            this.Corps = corps;
        }

        public string Corps { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            return sb.ToString().Trim();
        }
    }
}
