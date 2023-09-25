using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int badges = 0;
        private List<Pokemon> pokemons = new List<Pokemon>();

        public Trainer(string name, Pokemon pokemon)
        {
            this.name = name;
            this.pokemons.Add(pokemon);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public void AddBadge()
        {
            this.badges++;
        }

        public void ReducePokemonsHealth()
        {
            this.pokemons.ForEach(pokemon => pokemon.Health -= 10);
        }

        public void RemoveDeadPokemons()
        {
            this.pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
        }

        public override string ToString()
        {
            return $"{this.name} {this.badges} {this.pokemons.Count}";
        }
    }
}
