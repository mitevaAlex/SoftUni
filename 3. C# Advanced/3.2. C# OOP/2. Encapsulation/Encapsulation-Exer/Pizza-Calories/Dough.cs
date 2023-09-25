using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories
{
    public class Dough
    {
        private const double BaseCalories = 2;
        private const double WhiteCalories = 1.5;
        private const double WholegrainCalories = 1;
        private const double CrispyCalories = 0.9;
        private const double ChewyCalories = 1.1;
        private const double HomemadeCalories = 1;

        private string flourType;
        private string bakingTechnique;
        private int weight;//grams

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get { return this.flourType; }
            set
            {
                string input = value.ToUpper();
                if (input != "WHITE" && input != "WHOLEGRAIN")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = input;
            }
        }

        private string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                string input = value.ToUpper();
                if (input != "CRISPY" && input != "CHEWY" && input != "HOMEMADE")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = input;
            }
        }

        private int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double result = BaseCalories;
                switch (this.FlourType)
                {
                    case "WHITE":
                        result *= WhiteCalories;
                        break;
                    case "WHOLEGRAIN":
                        result *= WholegrainCalories;
                        break;
                }

                switch (this.bakingTechnique)
                {
                    case "CRISPY":
                        result *= CrispyCalories;
                        break;
                    case "CHEWY":
                        result *= ChewyCalories;
                        break;
                    case "HOMEMADE":
                        result *= HomemadeCalories;
                        break;
                }

                return result * this.Weight;
            }
        }

        public override string ToString()
        {
            return $"{this.Calories:F2}";
        }
    }
}
