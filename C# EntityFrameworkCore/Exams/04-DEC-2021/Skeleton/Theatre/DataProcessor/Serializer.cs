namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theathers = context.Theatres.ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .OrderByDescending(x => x.NumberOfHalls)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Sum(x => x.Price),
                    Tickets = x.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .ToArray()
                    .OrderByDescending(x => x.Price)
                    .Select(x => new
                    {
                        Price = x.Price,
                        RowNumber = x.RowNumber
                    }).ToArray()
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(theathers, Formatting.Indented);
            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays.ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new ExportPlayDto()
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts.ToArray()
                    .Where(x=> x.IsMainCharacter)
                    .Select(x => new ExportActorDto()
                    {
                        FullName = x.FullName,
                        MainCharacter = $"Plays main character in '{x.Play.Title}'."
                    })
                    .OrderByDescending(x => x.FullName)
                    .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            var xml = XmlConverter.Serialize(plays, "Plays");
            return xml;
        }
    }
}
