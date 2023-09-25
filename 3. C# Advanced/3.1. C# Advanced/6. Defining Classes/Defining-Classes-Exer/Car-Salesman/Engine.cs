using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement = -1;
        private string efficiency = "No efficiency";

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }

        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

        public static Engine CreateEngine(string[] engineArgs)
        {
            //"{model} {power} {displacement} {efficiency}" / "{model} {power} {displacement}" / "{model} {power} {efficiency}" / "{model} {power}"
            Engine engine;
            switch (engineArgs.Length)
            {
                case 4:
                    engine = new Engine(engineArgs[0], int.Parse(engineArgs[1]), int.Parse(engineArgs[2]), engineArgs[3]);
                    break;
                case 3:
                    if (int.TryParse(engineArgs[2], out int displacement))
                    {
                        engine = new Engine(engineArgs[0], int.Parse(engineArgs[1]), displacement);
                    }
                    else
                    {
                        engine = new Engine(engineArgs[0], int.Parse(engineArgs[1]), engineArgs[2]);
                    }
                    break;
                case 2:
                    engine = new Engine(engineArgs[0], int.Parse(engineArgs[1]));
                    break;
                default:
                    engine = null;
                    break;
            }

            return engine;
        }
    }
}
