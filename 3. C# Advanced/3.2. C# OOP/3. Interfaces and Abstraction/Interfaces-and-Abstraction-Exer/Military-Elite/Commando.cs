using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_Elite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, params Mission[] missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions.ToList();
        }

        public List<Mission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            this.Missions.ForEach(x => sb.AppendLine($"  {x}"));
            return sb.ToString().Trim();
        }

    }
}
