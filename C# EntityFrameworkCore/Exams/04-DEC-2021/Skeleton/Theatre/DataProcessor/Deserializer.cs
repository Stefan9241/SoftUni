namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var dtos = XmlConverter.Deserializer<ImportPlayDto>(xmlString, "Plays");
            var sb = new StringBuilder();
            foreach (var item in dtos)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var itemTimeSpan = TimeSpan.Parse(item.Duration, CultureInfo.InvariantCulture);
                if (itemTimeSpan.Hours == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                object enumType;
                bool isEnumValid = Enum.TryParse(typeof(Genre), item.Genre,out enumType);
                if(!isEnumValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play()
                {
                    Title = item.Title,
                    Duration = itemTimeSpan,
                    Rating = item.Rating,
                    Genre = (Genre)enumType,
                    Description = item.Description,
                    Screenwriter = item.Screenwriter
                };

                context.Plays.Add(play);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportPlay, item.Title,item.Genre, item.Rating));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var dtos = XmlConverter.Deserializer<ImportCastDto>(xmlString, "Casts");
            var sb = new StringBuilder();
            foreach (var item in dtos)
            {
                if(!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = item.FullName,
                    IsMainCharacter = item.IsMainCharacter,
                    PhoneNumber = item.PhoneNumber,
                    PlayId = item.PlayId
                };

                context.Casts.Add(cast);
                context.SaveChanges();

                var importance = item.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(String.Format(SuccessfulImportActor,item.FullName, importance));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportProjectionDto[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var item in dtos)
            {
                if (!IsValid(item) || item.Tickets.Any(x=> !IsValid(x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theather = new Theatre()
                {
                    Director = item.Director,
                    NumberOfHalls = item.NumberOfHalls,
                    Name = item.Name,
                };

                theather.Tickets = item.Tickets.Select(x => new Ticket()
                {
                    PlayId = x.PlayId,
                    RowNumber = x.RowNumber,
                    Price = x.Price,
                    Theatre = theather
                }).ToArray();

                context.Theatres.Add(theather);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportTheatre, item.Name, item.Tickets.Count()));
            }


            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
