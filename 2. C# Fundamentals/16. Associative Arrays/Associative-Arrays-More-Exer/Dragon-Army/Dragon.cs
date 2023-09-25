using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Army
{
    class Dragon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public Dragon(string name, int damage, int health, int armor)
        {
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }
    }
}
