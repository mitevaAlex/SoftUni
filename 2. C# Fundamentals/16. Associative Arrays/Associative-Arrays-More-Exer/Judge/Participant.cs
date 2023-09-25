using System;
using System.Collections.Generic;
using System.Text;

namespace Judge
{
    class Participant
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Participant(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
}
