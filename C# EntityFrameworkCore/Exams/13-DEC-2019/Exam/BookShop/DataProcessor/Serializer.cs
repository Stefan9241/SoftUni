namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                            .OrderByDescending(ab => ab.Book.Price)
                            .Select(ab => new
                            {
                                BookName = ab.Book.Name,
                                BookPrice = ab.Book.Price.ToString("f2")
                            })
                            .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a=> a.AuthorName)
                .ToArray();

            var jsonAuthors = JsonConvert.SerializeObject(authors,Formatting.Indented);
            return jsonAuthors;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            ExportBookDto[] books = context.Books
                .Where(x => x.PublishedOn < date && (int)x.Genre == 3)
                .ToArray()
                .OrderByDescending(x=> x.Pages)
                .ThenByDescending(x=> x.PublishedOn)
                .Select(x=> new ExportBookDto()
                {
                    Name = x.Name,
                    Pages = x.Pages,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray();

            var result = XmlConverter.Serialize(books, "Books");
            return result;
        }
    }
}