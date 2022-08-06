using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"[A-z0-9\s\.\-]+")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required]
        public string Trophies { get; set; }

        public HashSet<int> Footballers { get; set; }
    }
}
