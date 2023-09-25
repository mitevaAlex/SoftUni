using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseHealth { get; }

        public double Armor
        {
            get { return armor; }
            protected set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double BaseArmor { get; }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public bool IsAlive { get; protected set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            double healthReduce = hitPoints - Armor;
            Armor -= hitPoints;
            if (healthReduce > 0)
            {
                Health -= healthReduce;
            }

            if (Health == 0)
            {
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}