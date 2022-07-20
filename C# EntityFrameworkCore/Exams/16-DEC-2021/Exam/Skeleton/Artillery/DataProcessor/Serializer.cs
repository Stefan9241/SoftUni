
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(x => x.ShellWeight > shellWeight)
                .OrderBy(s => s.ShellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                          .Where(g => (int)g.GunType == 3)
                          .OrderByDescending(g => g.GunWeight)
                          .Select(ng => new
                          {
                              GunType = ng.GunType.ToString(),
                              GunWeight = ng.GunWeight,
                              BarrelLength = ng.BarrelLength,
                              Range = ng.Range > 3000 ? "Long-range" : "Regular range",
                          })
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(shells,Formatting.Indented);
            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(x => x.BarrelLength)
                .Select(x => new ExportGunsDto
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                                .Where(cg => cg.Country.ArmySize > 4500000)
                                .OrderBy(cg => cg.Country.ArmySize)
                                .Select(cg => new ExportCountriesDto
                                {
                                    ArmySize = cg.Country.ArmySize,
                                    Country = cg.Country.CountryName
                                })
                                .ToArray()
                })
                .ToArray();

            var xml = XmlConverter.Serialize(guns,"Guns");

            return xml;
        }
    }
}
