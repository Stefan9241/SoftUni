using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [Required]
        [StringLength(50,MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(0.0,10.00)]
        public float Rating { get; set; }

        [Required]
        public string Genre { get; set; }
        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Screenwriter { get; set; }
    }
}
