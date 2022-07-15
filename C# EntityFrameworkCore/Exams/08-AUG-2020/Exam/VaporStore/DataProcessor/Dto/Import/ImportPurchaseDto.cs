using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [Required]
        [XmlElement("Type")]
        public PurchaseType? Type { get; set; }
        [Required]
        [RegularExpression("^(\\w{4}-\\w{4}-\\w{4})$")]
        public string Key { get; set; }

        [Required]
        [RegularExpression("^(\\d{4} \\d{4} \\d{4} \\d{4})$")]
        public string Card { get; set; }

        [Required]
        public string Date { get; set; }
    }
}

