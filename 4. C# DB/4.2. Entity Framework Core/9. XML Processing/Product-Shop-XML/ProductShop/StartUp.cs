namespace ProductShop
{
    using System;
    using Data;
    using ProductShop.Models;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using ProductShop.DTO.Import;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.DTO.Export;
    using System.Xml.Linq;
    using System.Xml;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static MapperConfiguration mapConfig = new MapperConfiguration(x => x.AddProfile<ProductShopProfile>());
        public static IMapper mapper = mapConfig.CreateMapper();

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //context.Database.EnsureCreated();

            //string usersXml = new StreamReader("Datasets/users.xml").ReadToEnd();
            //Console.WriteLine(ImportUsers(context, usersXml));

            //string productsXml = new StreamReader("Datasets/products.xml").ReadToEnd();
            //Console.WriteLine(ImportProducts(context, productsXml));

            //string categoriesXml = new StreamReader("Datasets/categories.xml").ReadToEnd();
            //Console.WriteLine(ImportCategories(context, categoriesXml));

            //string categoriesProductsXml = new StreamReader("Datasets/categories-products.xml").ReadToEnd();
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));

            //Console.WriteLine(GetProductsInRange(context));

            //Console.WriteLine(GetSoldProducts(context));

            //Console.WriteLine(GetCategoriesByProductsCount(context));

            Console.WriteLine(GetUsersWithProducts(context));



        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            ImportUserDto[] users = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));
            context.Users.AddRange(mapper.Map<User[]>(users));
            context.SaveChanges();

            return $"Successfully imported {context.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            ImportProductDto[] products = (ImportProductDto[])serializer.Deserialize(new StringReader(inputXml));
            context.Products.AddRange(mapper.Map<Product[]>(products));
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            ImportCategoryDto[] categories = (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));
            context.Categories.AddRange(mapper.Map<Category[]>(categories));
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            ImportCategoryProductDto[] categoriesProducts = (ImportCategoryProductDto[])serializer
                .Deserialize(new StringReader(inputXml));
            categoriesProducts = categoriesProducts
                .Where(x =>
                context.Categories.FirstOrDefault(y => y.Id == x.CategoryId) != null
                && context.Products.FirstOrDefault(y => y.Id == x.ProductId) != null)
                .ToArray();
            context.CategoryProducts.AddRange(mapper.Map<CategoryProduct[]>(categoriesProducts));
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductPriceBuyerDto[] products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .ProjectTo<ExportProductPriceBuyerDto>(mapConfig)
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductPriceBuyerDto[]), new XmlRootAttribute("Products"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, products, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("products-in-range.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserSoldProductsDto[] usersProducts = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .ProjectTo<ExportUserSoldProductsDto>(mapConfig)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserSoldProductsDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, usersProducts, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("users-sold-products.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoryInfoDto[] categories = context.Categories
                .ProjectTo<ExportCategoryInfoDto>(mapConfig)
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoryInfoDto[]), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, categories, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("categories-by-products.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersProducts = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new ExportUserInfoDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProductsInfo = new ExportSoldProductsInfoDTO()
                    {
                        Count = x.ProductsSold.Count,
                        SoldProducts = x.ProductsSold
                        .Select(y => mapper.Map<ExportProductPriceDto>(y))
                        .OrderByDescending(y => decimal.Parse(y.Price))
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProductsInfo.Count)
                .Take(10)
                .ToArray();

            int usersSellersCount = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Count();

            ExportSellersInfoDto sellersInfo = new ExportSellersInfoDto()
            {
                Count = usersSellersCount,
                Users = usersProducts
            };

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSellersInfoDto));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, sellersInfo, namespaces);
            }

            using (StreamWriter sw = new StreamWriter("users-and-products.xml"))
            {
                sw.Write(sb.ToString().Trim());
            }

            return sb.ToString().Trim();
        }
    }
}