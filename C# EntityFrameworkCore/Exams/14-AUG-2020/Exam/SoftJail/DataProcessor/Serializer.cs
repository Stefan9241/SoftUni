﻿namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                                 .Select(o => new
                                 {
                                     OfficerName = o.Officer.FullName,
                                     Department = o.Officer.Department.Name
                                 })
                                 .OrderBy(x=> x.OfficerName)
                                 .ToArray(),
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(x=> x.Officer.Salary).ToString("F2"))
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var splittedPrisoners = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var prisoners = context.Prisoners
                .Where(x => splittedPrisoners.Contains(x.FullName))
                .Select(x => new ExportPrisonerMessageDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(x => new ExportMessageDto
                    {
                        Description = new string(x.Description.ToCharArray().Reverse().ToArray())
                        //Array.Reverse(x.Description.ToCharArray())
                    }).ToArray()
                })
                .ToArray()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();


            return XmlConverter.Serialize<ExportPrisonerMessageDto[]>(prisoners, "Prisoners");
        }
    }
}