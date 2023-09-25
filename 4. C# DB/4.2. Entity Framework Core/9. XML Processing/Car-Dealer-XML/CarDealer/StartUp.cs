using System;
using CarDealer.Data;
using System.IO;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System.Linq;
using System.Collections.Generic;
using CarDealer.DTO.Export;
using AutoMapper.QueryableExtensions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static MapperConfiguration mapConfig = new MapperConfiguration(x => x.AddProfile<CarDealerProfile>());
        public static IMapper mapper = mapConfig.CreateMapper();

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureCreated();

            //string suppliersXml = new StreamReader("Datasets/suppliers.xml").ReadToEnd();
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            //string partsXml = new StreamReader("Datasets/parts.xml").ReadToEnd();
            //Console.WriteLine(ImportParts(context, partsXml));

            //string carsXml = new StreamReader("Datasets/cars.xml").ReadToEnd();
            //Console.WriteLine(ImportCars(context, carsXml));

            //string customersXml = new StreamReader("Datasets/customers.xml").ReadToEnd();
            //Console.WriteLine(ImportCustomers(context, customersXml));

            //string salesXml = new StreamReader("Datasets/sales.xml").ReadToEnd();
            //Console.WriteLine(ImportSales(context, salesXml));

            //Console.WriteLine(GetCarsWithDistance(context));

            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //Console.WriteLine(GetLocalSuppliers(context));

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Console.WriteLine(GetTotalSalesByCustomer(context));
            
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));
            ImportSupplierDto[] suppliers = (ImportSupplierDto[])serializer.Deserialize(new StringReader(inputXml));
            context.Suppliers.AddRange(mapper.Map<Supplier[]>(suppliers));
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));
            ImportPartDto[] parts = (ImportPartDto[])serializer.Deserialize(new StringReader(inputXml));
            parts = parts
                .Where(x => context.Suppliers.FirstOrDefault(y => y.Id == x.SupplierId) != null)
                .ToArray();
            context.Parts.AddRange(mapper.Map<Part[]>(parts));
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            ImportCarDto[] cars = (ImportCarDto[])serializer.Deserialize(new StringReader(inputXml));
            cars
                .ToList()
                .ForEach(x => x.Parts = x.Parts
                    .Distinct()
                    .Where(y => context.Parts.FirstOrDefault(z => z.Id == y.Id) != null)
                    .ToList());

            context.Cars.AddRange(mapper.Map<Car[]>(cars));
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            ImportCustomerDto[] customers = (ImportCustomerDto[])serializer.Deserialize(new StringReader(inputXml));
            context.Customers.AddRange(mapper.Map<Customer[]>(customers));
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            ImportSaleDto[] sales = (ImportSaleDto[])serializer.Deserialize(new StringReader(inputXml));
            sales = sales
                .Where(x => context.Cars.FirstOrDefault(y => y.Id == x.CarId) != null)
                .ToArray();
            context.Sales.AddRange(mapper.Map<Sale[]>(sales));
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarBasicInfoDto[] cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .ProjectTo<ExportCarBasicInfoDto>(mapConfig)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarBasicInfoDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, cars, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("cars.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportBMWDto[] cars = context.Cars
                .Where(x => x.Make == "BMW")
                .ProjectTo<ExportBMWDto>(mapConfig)
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportBMWDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, cars, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("bmw-cars.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSupplierDto[] suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .ProjectTo<ExportLocalSupplierDto>(mapConfig)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), new XmlRootAttribute("suppliers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, suppliers, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("local-suppliers.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Include(x => x.PartCars)
                .ThenInclude(x => x.Part)
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ProjectTo<ExportCarPartsDto>(mapConfig)
                .ToArray();
            cars
                .ToList()
                .ForEach(car => car.Parts = car.Parts
                    .OrderByDescending(x => x.Price).ToList());

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarPartsDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, cars, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("cars-and-parts.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportBuyerDto[] finalBuyers = context.Customers
                .Where(x => x.Sales.Count() >= 1)
                .Select(x => new ExportBuyerDto
                {
                    Name = x.Name,
                    BoughtCarsCount = x.Sales.Count,
                    SpentMoney = x.Sales.SelectMany(s => s.Car.PartCars.Select(pc => pc.Part.Price)).Sum()
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportBuyerDto[]), new XmlRootAttribute("customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, finalBuyers, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("customers-total-sales.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDto[] sales = context.Sales
                .Include(x => x.Customer)
                .Include(x => x.Car.PartCars)
                .ThenInclude(x => x.Part)
                .ToArray()
                .Select(x => new ExportSaleDto()
                {
                    Car = mapper.Map<ExportCarBasicAttributesDto>(x.Car),
                    Discount = (int)x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(y => y.Part.Price).ToString().Trim('0'),
                    PriceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) * ((100 - x.Discount) / 100)).ToString().Trim('0')
                })
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSaleDto[]), new XmlRootAttribute("sales"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, sales, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("sales-discounts.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }
    }
}