using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Team_Generator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value; 
            }
        }

        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                this.ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                this.ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double SkillLevel => (this.Endurance + this.Dribble + this.Sprint + this.Shooting + this.Passing) / 5.0;

        private void ValidateStat(int value, string propName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{propName} should be between 0 and 100.");
            }
        }
    }
}
