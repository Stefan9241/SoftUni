﻿using BookShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBookDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(1,3)]
        [XmlElement("Genre")]
        public int Genre { get; set; }
        [Range(typeof(decimal),"0.1", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }
        [Range(50,5000)]
        [XmlElement("Pages")]
        public int Pages { get; set; }
        
        [XmlElement("PublishedOn")]
        public string PublishedOn { get; set; }
    }
}
