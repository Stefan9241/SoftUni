namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var countriesDtos = XmlConverter.Deserializer<ImportCountryDto>(xmlString, "Countries");
            var sb = new StringBuilder();
            foreach (var item in countriesDtos)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country { ArmySize = item.ArmySize, CountryName = item.CountryName };
                context.Countries.Add(country);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportCountry, item.CountryName, item.ArmySize));
            }


            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var manufactDtos = XmlConverter.Deserializer<ImportManufacurerDtop>(xmlString, "Manufacturers");
            var sb = new StringBuilder();

            foreach (var item in manufactDtos)
            {
                if(!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(context.Manufacturers.Any(x=> x.ManufacturerName == item.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var founded = item.Founded.Split(", ").TakeLast(2);
                var manufacturer = new Manufacturer()
                {
                    Founded = string.Join(", ", founded),
                    ManufacturerName = item.ManufacturerName
                };

                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportManufacturer,item.ManufacturerName,manufacturer.Founded));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var shellsDtos = XmlConverter.Deserializer<ImportShellsDto>(xmlString, "Shells");
            var sb = new StringBuilder();

            foreach (var item in shellsDtos)
            {
                if(!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell()
                {
                    Caliber = item.Caliber,
                    ShellWeight = item.ShellWeight
                };

                context.Shells.Add(shell);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportShell,shell.Caliber,shell.ShellWeight));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var guns = JsonConvert.DeserializeObject<ImportArtileryDto[]>(jsonString);
            var sb = new StringBuilder();
            foreach (var item in guns)
            {
                if(!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object positionObj;
                bool isPositionValid = Enum.TryParse(typeof(GunType), item.GunType, out positionObj);

                if (!isPositionValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var shell = context.Shells.Where(x => x.Id == item.ShellId).FirstOrDefault();
                var gun = new Gun()
                {
                    BarrelLength = item.BarrelLength,
                    GunWeight = item.GunWeight,
                    NumberBuild = item.NumberBuild,
                    Range = item.Range,
                    Shell = shell,
                    ManufacturerId = item.ManufacturerId,
                    GunType = (GunType)positionObj,
                };

                gun.CountriesGuns = item.Countries.Select(x => new CountryGun() { CountryId = x.Id, GunId = gun.Id }).ToArray();
                context.Guns.Add(gun);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportGun,gun.GunType,gun.GunWeight,gun.BarrelLength));
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
