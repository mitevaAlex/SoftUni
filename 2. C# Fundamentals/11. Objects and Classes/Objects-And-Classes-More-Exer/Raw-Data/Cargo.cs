using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    class Cargo
    {
        public string Type { get; set; }
        public int Weight { get; set; }

        public Cargo(int weight, string type)
        {
            this.Type = type;
            this.Weight = weight;
        }
    }
}
