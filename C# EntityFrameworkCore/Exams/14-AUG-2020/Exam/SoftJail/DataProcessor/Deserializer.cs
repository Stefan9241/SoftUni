namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var depNamesDtos = JsonConvert.DeserializeObject<ImportNameDto[]>(jsonString);
            var sb = new StringBuilder();
            foreach (var item in depNamesDtos)
            {
                if(!IsValid(item) || item.Cells.Length == 0 || !item.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var dep = new Department()
                {
                    Name = item.Name,
                    Cells = item.Cells.Select(x => new Cell()
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow,
                    }).ToArray()
                };

                context.Departments.Add(dep);
                context.SaveChanges();

                sb.AppendLine($"Imported {item.Name} with {item.Cells.Length} cells");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);
            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();
            foreach (var item in prisonersDtos)
            {
                if(!IsValid(item) || !item.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleaseDate = DateTime
                    .TryParseExact(item.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate
                    );

                var incDate = DateTime.ParseExact(
                    item.IncarcerationDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

                var prisoner = new Prisoner
                {
                    FullName = item.FullName,
                    Nickname = item.Nickname,
                    Age = item.Age,
                    Bail = item.Bail,
                    CellId = item.CellId,
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    IncarcerationDate = incDate,
                    Mails = item.Mails.Select(x=> new Mail
                    {
                        Sender = x.Sender,
                        Address = x.Address,
                        Description = x.Description
                    }).ToArray()
                };

                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {item.FullName} {item.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var officersDtos = XmlConverter.Deserializer<ImportOfficersDto>(xmlString,"Officers");
            var sb = new StringBuilder();

            foreach (var item in officersDtos)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                object positionObj;
                var isPositionValid = Enum.TryParse(typeof(Position), item.Position.ToString(), out positionObj);
                //bool isPositionValid = Enum.TryParse(typeof(Position), item.Position, out positionObj);
                //Enum.Parse<Position>(officer.Weapon)
                if (!isPositionValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                object weaponObj;
                bool isWeaponValid = Enum.TryParse(typeof(Weapon), item.Weapon.ToString(), out weaponObj);

                if (!isWeaponValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                var officer = new Officer
                {
                    FullName = item.FullName,
                    Salary = item.Salary,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)weaponObj,
                    DepartmentId = item.DepartmentId,
                };

                foreach (var prisoners in item.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisoners.Id
                    });
                }

                context.Officers.Add(officer);
                context.SaveChanges();

                sb.AppendLine($"Imported {item.FullName} ({item.Prisoners.Length} prisoners)");
            }


            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}