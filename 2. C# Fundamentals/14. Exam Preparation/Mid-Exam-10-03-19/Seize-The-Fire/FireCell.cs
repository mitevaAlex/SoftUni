using System;
using System.Collections.Generic;
using System.Text;

namespace Seize_The_Fire
{
    class FireCell
    {
        public string FireType { get; set; }
        public int Value { get; set; }

        public FireCell(string type, int value)
        {
            this.FireType = type;
            this.Value = value;
        }

        public bool IsValueValid()
        {
            if (this.FireType == "High")
            {
                return this.Value >= 81 && this.Value <= 125;
            }

            if (this.FireType == "Medium")
            {
                return this.Value >= 51 && this.Value <= 80;
            }

            if (this.FireType == "Low")
            {
                return this.Value >= 1 && this.Value <= 50;
            }
            return false;
        }

        public override string ToString()
        {
            return $" - {this.Value}";
        }
    }
}
