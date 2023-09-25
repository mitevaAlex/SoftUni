using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliersJson = File.ReadAllText("Datasets\\suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, suppliersJson));

            //string partsJson = File.ReadAllText("Datasets\\parts.json");
            //Console.WriteLine(ImportParts(context, partsJson));

            //string carsJson = File.ReadAllText("Datasets\\cars.json");
            //Console.WriteLine(ImportCars(context, carsJson));

            //string customersJson = File.ReadAllText("Datasets\\customers.json");
            //Console.WriteLine(ImportCustomers(context, customersJson));

            //string salesJson = File.ReadAllText("Datasets\\sales.json");
            //Console.WriteLine(ImportSales(context, salesJson));

            //Console.WriteLine(GetOrderedCustomers(context));

            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //Console.WriteLine(GetLocalSuppliers(context));

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Console.WriteLine(GetTotalSalesByCustomer(context));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<Supplier> suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {context.Suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IEnumerable<Part> parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson)
                .Where(x => context.Suppliers.FirstOrDefault(y => y.Id == x.SupplierId) != null);
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {context.Parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            IEnumerable<CarDTO> carsDTO = JsonConvert.DeserializeObject<IEnumerable<CarDTO>>(inputJson);

            foreach (var carDTO in carsDTO)
            {
                Car car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDTO.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();
            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {context.Customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<Sale> sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {context.Sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = x.IsYoungDriver
                });
            string customersJson = JsonConvert.SerializeObject(customers);
            File.WriteAllText("ordered-customers.json", customersJson);
            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                });
            string carsJson = JsonConvert
                .SerializeObject(cars,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
            File.WriteAllText("toyota-cars.json", carsJson);
            return carsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                });
            string suppliersJson = JsonConvert.SerializeObject(suppliers);
            File.WriteAllText("local-suppliers.json", suppliersJson);
            return suppliersJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars
                    .Select(y => new
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price.ToString("F2")
                    })
                });

            List<CarPartsDTO> carsDTO = new List<CarPartsDTO>();
            foreach (var car in cars)
            {
                CarPartsDTO carPartsDTO = new CarPartsDTO()
                {
                    Car = new BasicCarDTO()
                    {
                        Make = car.Make,
                        Model = car.Model,
                        TravelledDistance = car.TravelledDistance
                    },
                    Parts = car.Parts
                    .Select(x => new PartDTO()
                    {
                        Name = x.Name,
                        Price = x.Price
                    })
                    .ToArray()
                };

                carsDTO.Add(carPartsDTO);
            }

            string carsJson = JsonConvert.SerializeObject(carsDTO);
            File.WriteAllText("cars-and-parts.json", carsJson);
            return carsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars);

            string customersJson = JsonConvert
                .SerializeObject(customers, 
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });
            File.WriteAllText("customers-total-sales.json", customersJson);
            return customersJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(y => y.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) * ((100 - x.Discount) / 100)).ToString("F2")
                });

            string salesJson = JsonConvert.SerializeObject(sales);
            File.WriteAllText("sales-discounts.json", salesJson);
            return salesJson;
        }
    }
}