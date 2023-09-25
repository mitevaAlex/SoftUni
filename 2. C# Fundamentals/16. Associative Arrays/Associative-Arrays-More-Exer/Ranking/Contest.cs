using System;
using System.Collections.Generic;
using System.Text;

namespace Ranking
{
    class Contest
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Contest(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public override string ToString()
        {
            return $"#  {this.Name} -> {this.Points}";
        }
    }
}
