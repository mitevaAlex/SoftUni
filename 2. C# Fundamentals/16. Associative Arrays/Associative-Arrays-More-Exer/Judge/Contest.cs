using System;
using System.Collections.Generic;
using System.Text;

namespace Judge
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
    }
}
