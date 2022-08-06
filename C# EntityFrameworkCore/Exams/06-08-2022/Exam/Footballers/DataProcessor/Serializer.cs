namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .Where(x => x.Footballers.Any())
                .ToArray()
                .Select(c => new ExportCoachDto()
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers.Select(nf => new ExportFootballerDto()
                    {
                        Name = nf.Name,
                        Position = nf.PositionType.ToString(),
                    }
                    )
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            var xml = XmlConverter.Serialize<ExportCoachDto>(coaches, "Coaches");

            return xml;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(x => x.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(x => new
                {
                    Name = x.Name,
                    Footballers = x.TeamsFootballers
                    .Where(tf => tf.Footballer.ContractStartDate >= date)
                    .OrderByDescending(x => x.Footballer.ContractEndDate)
                    .ThenBy(x=> x.Footballer.Name)
                    .ToArray()
                    .Select(nf => new
                    {
                        FootballerName = nf.Footballer.Name,
                        ContractStartDate = nf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = nf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = nf.Footballer.BestSkillType.ToString(),
                        PositionType = nf.Footballer.PositionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(x => x.Footballers.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            var json = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return json;
        }
    }
}
