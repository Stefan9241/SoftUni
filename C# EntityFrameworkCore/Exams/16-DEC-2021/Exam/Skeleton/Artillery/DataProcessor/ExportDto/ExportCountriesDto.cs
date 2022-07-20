using System.Xml.Serialization;

[XmlType("Country")]
public class ExportCountriesDto
{
    [XmlAttribute("Country")]
    public string Country { get; set; }

    [XmlAttribute("ArmySize")]
    public int ArmySize { get; set; }
}
