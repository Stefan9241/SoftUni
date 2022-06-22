namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            //var input = int.Parse(Console.ReadLine());
            Console.WriteLine(RemoveBooks(db));
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count;
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var item in books)
            {
                item.Price += 5;
            }

            context.SaveChanges();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var category = context.Categories
                .Select(x => new
                {
                    catName = x.Name,
                    books = x.CategoryBooks
                    .Select(x => new
                    {
                        x.Book.Title,
                        x.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(x => x.Value)
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(x => x.catName)
                .ToArray();



            var sb = new StringBuilder();
            foreach (var item in category)
            {
                sb.AppendLine($"--{item.catName}");
                foreach (var book in item.books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }

            }

            return sb.ToString().Trim();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var category = context.Categories
                .Select(x => new
                {
                    CatName = x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.CatName)
                .ToArray();

            return string.Join(Environment.NewLine, category.Select(x => $"{x.CatName} ${x.Profit:f2}"));

        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    TotalCopies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.FirstName} {x.LastName} - {x.TotalCopies}"));
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToArray();

            return books.Length;
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.BookId,
                    Titles = x.Title,
                    FulName = x.Author.FirstName + " " + x.Author.LastName
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Titles} ({x.FulName})"));
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new { x.Title })
                .OrderBy(x => x.Title)
                .ToArray();

            return string.Join(Environment.NewLine, titles.Select(x => x.Title));
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = x.FirstName + ' ' + x.LastName
                })
                .OrderBy(x => x.FullName)
                .ToArray();

            return string.Join(Environment.NewLine, authors.Select(x => x.FullName));
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy",
                CultureInfo.InvariantCulture);
            var books = context.Books
                .OrderByDescending(x => x.ReleaseDate.Value)
                .Where(x => x.ReleaseDate.Value < targetDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToArray();



            var result = new StringBuilder();

            foreach (var item in books)
            {
                result.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price}");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var criterias = input.Split().Select(x => x.ToLower()).ToArray();


            var books = context.Books
                .OrderBy(x => x.Title)
                .Where(b => b.BookCategories
                        .Any(c => criterias
                        .Contains(c.Category.Name.ToLower())))
                .Select(x => x.Title)
                .ToArray();

            var result = new StringBuilder();

            foreach (var item in books)
            {
                result.AppendLine($"{item}");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var item in books)
            {
                result.AppendLine($"{item.Title}");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var titles = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    price = x.Price,
                    title = x.Title
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var item in titles)
            {
                result.AppendLine($"{item.title} - ${item.price:f2}");
            }

            return result.ToString().TrimEnd();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var title in titles)
            {
                result.AppendLine(title.Title);
            }

            return result.ToString().TrimEnd();
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var restrinction = Enum.Parse<AgeRestriction>(command, true);

            var titles = context.Books
                .Where(x => x.AgeRestriction == restrinction)
                .OrderBy(x => x.Title)
                .Select(x => new
                {
                    x.Title
                })
                .ToArray();

            var result = new StringBuilder();

            foreach (var title in titles)
            {
                result.AppendLine(title.Title);
            }

            return result.ToString().TrimEnd();
        }
    }
}
