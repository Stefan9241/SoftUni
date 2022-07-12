namespace BookShop.DataProcessor
{
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var books = XmlConverter.Deserializer<ImportBookDto>(xmlString, "Books");

            foreach (var book in books)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;
                bool isValidPublished =
                    DateTime.TryParseExact(
                        book.PublishedOn,
                        "MM/dd/yyyy",
                        CultureInfo.InvariantCulture
                        , DateTimeStyles.None,
                        out publishedOn);
                if (!isValidPublished)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Books.Add(new Book
                {
                    Genre = (Genre)book.Genre,
                    Name = book.Name,
                    Pages = book.Pages,
                    Price = book.Price,
                    PublishedOn = publishedOn
                });
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);
            var authros = new List<Author>();

            foreach (var authorDto in authorsDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                else if (authros.Any(x => x.Email == authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author()
                {
                    Email = authorDto.Email,
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                };


                foreach (var bookDto in authorDto.Books)
                {
                    if (!bookDto.BookId.HasValue)
                    {
                        continue;
                    }

                    var book = context.Books
                        .FirstOrDefault(b => b.Id == bookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book,
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authros.Add(author);
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));
            }
            context.Authors.AddRange(authros);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}