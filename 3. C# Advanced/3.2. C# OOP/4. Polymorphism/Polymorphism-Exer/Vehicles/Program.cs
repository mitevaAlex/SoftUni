using System;

namespace Vehicles
{
    class Program
    {
        static Car car;
        static Truck truck;
        static Bus bus;

        static void Main()
        {
            car = (Car)CreateVehicle();
            truck = (Truck)CreateVehicle();
            bus = (Bus)CreateVehicle();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] args = Console.ReadLine()
                    .Split(' ');
                string action = args[0];
                string vehicle = args[1];
                double kmOrLiters = double.Parse(args[2]);
                switch (action)
                {
                    case "Drive":
                        DriveVehicle(vehicle, kmOrLiters);
                        break;
                    case "DriveEmpty":
                        bus.Drive(kmOrLiters, "empty");
                        break;
                    case "Refuel":
                        RefuelVehicle(vehicle, kmOrLiters);
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        static Vehicle CreateVehicle()
        {
            string[] vehicleInfo = Console.ReadLine()
                .Split(' ');
            Vehicle vehicle = null;
            switch (vehicleInfo[0])
            {
                case "Car":
                    vehicle = new Car(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
                    break;
                case "Truck":
                    vehicle = new Truck(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
                    break;
                case "Bus":
                    vehicle = new Bus(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
                    break;
            }

            return vehicle;
        }

        static void DriveVehicle(string vehicleType, double km)
        {
            switch (vehicleType)
            {
                case "Car":
                    car.Drive(km);
                    break;
                case "Truck":
                    truck.Drive(km);
                    break;
                case "Bus":
                    bus.Drive(km, "full");
                    break;
            }
        }

        static void RefuelVehicle(string vehicleType, double km)
        {
            switch (vehicleType)
            {
                case "Car":
                    car.Refuel(km);
                    break;
                case "Truck":
                    truck.Refuel(km);
                    break;
                case "Bus":
                    bus.Refuel(km);
                    break;
            }
        }
    }
}
