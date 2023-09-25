using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionaPerKm = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionaPerKm { get; }

        public double TankCapacity { get; }

        public void Drive(double km)
        {
            double fuelNeeded = km * this.FuelConsumptionaPerKm;
            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{this.GetType().Name} travelled {km} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuelAmount + this.FuelQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuelAmount;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
