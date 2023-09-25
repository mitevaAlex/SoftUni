using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerConsumption = 1.6;
        private const double KeptFuelPercent = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + AirConditionerConsumption, tankCapacity)
        {
        }

        public override void Refuel(double fuelAmount)
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
                this.FuelQuantity += fuelAmount * KeptFuelPercent;
            }
        }
    }
}
