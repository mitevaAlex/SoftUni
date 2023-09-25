namespace BookShop
{
    using BookShop.Models;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //Console.WriteLine(GetGoldenBooks(db));

            //Console.WriteLine(GetBooksByPrice(db));

            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            //string categoriesString = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, categoriesString));

            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //string firstNameEnd = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, firstNameEnd));

            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, input));

            //int lengthCheck = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, lengthCheck));

            //Console.WriteLine(CountCopiesByAuthor(db));

            //Console.WriteLine(GetTotalProfitByCategory(db));

            //Console.WriteLine(GetMostRecentBooks(db));

            //IncreasePrices(db);

            RemoveBooks(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            command = command.ToUpper();

            var books = context.Books
                .ToArray()
                .Where(x => x.AgeRestriction.ToString().ToUpper() == command)
                .Select(x => x.Title)
                .OrderBy(x => x);

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .ToArray()
                .Where(x => x.EditionType.ToString() == "Gold" && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title);
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new { Title = x.Title, Price = x.Price })
                .OrderByDescending(x => x.Price);
            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:F2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .ToArray()
               .Where(x => DateTime.Parse(x.ReleaseDate.ToString()).Year != year)
               .OrderBy(x => x.BookId)
               .Select(x => x.Title);
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToUpper())
                .ToArray();

            List<string> books = new List<string>();
            foreach (string category in categories)
            {
                var currentBooks = context.Books
                    .Where(x => x.BookCategories.Select(y => y.Category.Name.ToUpper()).Contains(category))
                    .Select(x => x.Title);
                books.AddRange(currentBooks);
            }

            books = books
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime convertedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(x => x.ReleaseDate < convertedDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    Price = x.Price.ToString("F2")
                });

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price}"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .ToArray()
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => $"{x.FirstName} {x.LastName}")
                .OrderBy(x => x);

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToUpper();
            var books = context.Books
                .Where(x => x.Title.ToUpper().Contains(input))
                .Select(x => x.Title)
                .OrderBy(x => x);

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToUpper();
            var result = context.Books
                .Include(x => x.Author)
                .ToArray()
                .Where(x => x.Author.LastName.ToUpper().StartsWith(input))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})");

            return string.Join(Environment.NewLine, result);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    BooksCopiesCount = x.Books.Sum(y => y.Copies)
                })
                .OrderByDescending(x => x.BooksCopiesCount);

            return string.Join(Environment.NewLine, authors.Select(x => $"{x.AuthorName} - {x.BooksCopiesCount}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Category = x.Name,
                    Profit = x.CategoryBooks
                    .Select(y => y.Book.Price * y.Book.Copies)
                    .Sum()
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Category);

            return string.Join(Environment.NewLine, categories.Select(x => $"{x.Category} ${x.Profit:F2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    MostRecentBooks = x.CategoryBooks
                              .OrderByDescending(y => y.Book.ReleaseDate)
                              .Select(y => y.Book)
                              .Take(3)
                })
                .OrderBy(x => x.Name);

            StringBuilder result = new StringBuilder();
            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");
                foreach (var book in category.MostRecentBooks)
                {
                    result.AppendLine($"{book.Title} ({DateTime.Parse(book.ReleaseDate.ToString()).Year})");
                }
            }

            return result.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();

            //context.Books
            //    .Where(x => x.ReleaseDate.Value.Year < 2010)
            //    .Update(x => new Book { Price = x.Price + 5 });
        }

        public static int RemoveBooks(BookShopContext context)
        {
            return context.Books
                .Where(x => x.Copies < 4200)
                .Delete();
        }
    }
}
