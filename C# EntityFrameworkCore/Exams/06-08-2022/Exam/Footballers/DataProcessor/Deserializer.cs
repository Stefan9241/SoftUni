namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var coachDto = XmlConverter.Deserializer<ImportCoachDto>(xmlString, "Coaches");
            var sb = new StringBuilder();
            var validCoaches = new List<Coach>();

            foreach (var item in coachDto)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach()
                {
                    Name = item.Name,
                    Nationality = item.Nationality
                };

                foreach (var footballer in item.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var parsedDate = DateTime.TryParseExact(footballer.ContractStartDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var startDate);

                    if (!parsedDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var endDateParse = DateTime.TryParseExact(footballer.ContractEndDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var endDate);

                    if (!endDateParse)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (startDate > endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var position = Enum.Parse(typeof(PositionType), footballer.PositionType);
                    var bestSkill = Enum.Parse(typeof(BestSkillType), footballer.BestSkillType);

                    var foot = new Footballer()
                    {
                        Coach = coach,
                        Name = footballer.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = (BestSkillType)bestSkill,
                        PositionType = (PositionType)position
                    };

                    coach.Footballers.Add(foot);
                }

                validCoaches.Add(coach);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            var sb = new StringBuilder();
            var validTeams = new List<Team>();
            foreach (var item in dtos)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var parsedInt = int.TryParse(item.Trophies, out var trofy);
                if (!parsedInt || trofy <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = item.Name,
                    Nationality = item.Nationality,
                    Trophies = trofy,
                };

                foreach (var id in item.Footballers)
                {
                    var footballer = context.Footballers.FirstOrDefault(x => x.Id == id);
                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = footballer
                    });
                }

                validTeams.Add(team);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }
            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
