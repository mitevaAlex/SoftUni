using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
             : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public void Drive(double km, string state)//state = empty || full
        {
            double fuelNeeded = 0.0;
            if (state == "full")
            {
                fuelNeeded = km * (AirConditionerConsumption + this.FuelConsumptionaPerKm);
            }
            else if(state == "empty")
            {
                fuelNeeded = km * this.FuelConsumptionaPerKm;
            }

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
    }
}
