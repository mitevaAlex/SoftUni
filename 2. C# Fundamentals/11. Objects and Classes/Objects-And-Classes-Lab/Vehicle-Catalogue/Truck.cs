using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Catalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"{this.Brand}: {this.Model} - {this.Weight}kg"; 
        }
    }
}
