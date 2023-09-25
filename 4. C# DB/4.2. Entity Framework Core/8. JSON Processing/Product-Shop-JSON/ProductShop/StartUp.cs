using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //context.Database.EnsureCreated();

            //string usersJson = File.ReadAllText("Datasets\\users.json");
            //Console.WriteLine(ImportUsers(context, usersJson));

            //string productsJson = File.ReadAllText("Datasets\\products.json");
            //Console.WriteLine(ImportProducts(context, productsJson));

            //string categoriesJson = File.ReadAllText("Datasets\\categories.json");
            //Console.WriteLine(ImportCategories(context, categoriesJson));

            //string categoriesProductsJson = File.ReadAllText("Datasets\\categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJson));

            //Console.WriteLine(GetProductsInRange(context));

            //Console.WriteLine(GetSoldProducts(context));

            //Console.WriteLine(GetCategoriesByProductsCount(context));

            Console.WriteLine(GetUsersWithProducts(context));

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {context.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProduct> categoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);
            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                });

            string productsJson = JsonConvert
                .SerializeObject(products,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });
            File.WriteAllText("products-in-range.json", productsJson);
            return productsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count(y => y.BuyerId != null) >= 1)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Where(y => y.BuyerId != null)
                    .Select(y => new
                    {
                        Name = y.Name,
                        Price = y.Price,
                        BuyerFirstName = y.Buyer.FirstName,
                        BuyerLastName = y.Buyer.LastName,
                    })
                });

            string usersJson = JsonConvert
                .SerializeObject(users,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });
            File.WriteAllText("users-sold-products.json", usersJson);
            return usersJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count())
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(y => y.Product.Price).ToString("F2"),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price).ToString("F2")
                });

            string categoriesJson = JsonConvert
                .SerializeObject(categories,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });
            File.WriteAllText("categories-by-products.json", categoriesJson);
            return categoriesJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Count(y => y.BuyerId != null) >= 1)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Count(y => y.BuyerId != null),
                        Products = x.ProductsSold
                        .Where(y => y.BuyerId != null)
                        .Select(y => new
                        {
                            Name = y.Name,
                            Price = y.Price
                        })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count);

            object outputObject = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            string usersJson = JsonConvert
                .SerializeObject(outputObject,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    NullValueHandling = NullValueHandling.Ignore
                });
            File.WriteAllText("users-and-products.json", usersJson);
            return usersJson;
        }
    }
}