using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }


        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }

        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
