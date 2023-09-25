using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Team_Generator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new Dictionary<string, Player>();
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

        public int Rating => (int)Math.Round(players.Sum(x => x.Value.SkillLevel));

        public void AddPlayer(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(name, endurance, sprint, dribble, passing, shooting);
            this.players.Add(name, player);
        }
        public void RemovePlayer(string name)
        {
            if (!this.players.ContainsKey(name))
            {
                throw new ArgumentException($"Player {name} is not in {this.name} team.");
            }

            this.players.Remove(name);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
