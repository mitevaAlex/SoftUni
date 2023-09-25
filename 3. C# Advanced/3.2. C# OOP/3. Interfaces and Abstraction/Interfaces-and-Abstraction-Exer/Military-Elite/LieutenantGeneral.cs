using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_Elite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params Private[] privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates.ToList(); 
        }
        public List<Private> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            this.Privates.ForEach(x => sb.AppendLine($"  {x}"));
            return sb.ToString().Trim();
        }

    }
}
