using System;
using System.Collections.Generic;
using System.Text;

namespace Snowwhite
{
    class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }
        public Dwarf(string hatColor, int physics)
        {
            this.HatColor = hatColor;
            this.Physics = physics;
        }

        public Dwarf(string name, string hatColor, int physics)
        {
            this.Name = name;
            this.HatColor = hatColor;
            this.Physics = physics;
        }
    }
}
