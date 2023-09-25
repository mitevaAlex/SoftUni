using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        private double pressure;
        private int age;

        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }

        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public static Tire[] CreateTireArray(string[] pressuresAndAges)
        {
            List<Tire> tires = new List<Tire>();
            for (int i = 0; i < pressuresAndAges.Length; i += 2)
            {
                Tire tire = new Tire(double.Parse(pressuresAndAges[i]), int.Parse(pressuresAndAges[i + 1]));
                tires.Add(tire);
            }

            return tires.ToArray();
        }
    }
}
