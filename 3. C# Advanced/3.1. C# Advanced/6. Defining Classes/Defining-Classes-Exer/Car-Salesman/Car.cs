using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight = -1;
        private string color = "No color";

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.weight = weight;
            this.color = color;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public static Car CreateCar(string[] carArgs, Dictionary<string, Engine> engines)
        {
            // "{model} {engine} {weight} {color}" / "{model} {engine} {weight}"/ "{model} {engine} {color}" / "{model} {engine}"
            Car car;
            switch (carArgs.Length)
            {
                case 4:
                    car = new Car(carArgs[0], engines[carArgs[1]], int.Parse(carArgs[2]), carArgs[3]);
                    break;
                case 3:
                    if (int.TryParse(carArgs[2], out int weight))
                    {
                        car = new Car(carArgs[0], engines[carArgs[1]], weight);
                    }
                    else
                    {
                        car = new Car(carArgs[0], engines[carArgs[1]], carArgs[2]);
                    }
                    break;
                case 2:
                    car = new Car(carArgs[0], engines[carArgs[1]]);
                    break;
                default:
                    car = null;
                    break;
            }

            return car;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.model}:{Environment.NewLine}");
            sb.Append($"  {this.engine.Model}:{Environment.NewLine}");
            sb.Append($"    Power: {this.engine.Power}{Environment.NewLine}");
            sb.Append(this.engine.Displacement == -1 ? $"    Displacement: n/a{Environment.NewLine}" : $"    Displacement: {this.engine.Displacement}{Environment.NewLine}");
            sb.Append(this.engine.Efficiency == "No efficiency" ? $"    Efficiency: n/a{Environment.NewLine}" : $"    Efficiency: {this.engine.Efficiency}{Environment.NewLine}");
            sb.Append(this.weight == -1 ? $"  Weight: n/a{Environment.NewLine}" : $"  Weight: {this.weight}{Environment.NewLine}");
            sb.Append(this.color == "No color" ? "  Color: n/a" : $"  Color: {this.color}");
            return sb.ToString();
        }
    }
}
