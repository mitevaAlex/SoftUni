using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle_Catalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public Vehicle(string type, string model, string color, int horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public override string ToString()
        {
            return $"Type: {this.Type}{Environment.NewLine}" +
                $"Model: {Model}{Environment.NewLine}" +
                $"Color: {this.Color}{Environment.NewLine}" +
                $"Horsepower: {this.Horsepower}"; 
        }
    }
}
