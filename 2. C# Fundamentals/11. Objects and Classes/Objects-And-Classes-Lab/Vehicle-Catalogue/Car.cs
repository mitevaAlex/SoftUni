using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Catalogue
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Horsepower { get; set; }

        public Car(string brand, string model, int horsepower)
        {
            this.Brand = brand;
            this.Model = model;
            this.Horsepower = horsepower;
        }

        public override string ToString()
        {
            return $"{this.Brand}: {this.Model} - {this.Horsepower}hp";
        }
    }
}
