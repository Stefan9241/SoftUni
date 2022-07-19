using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }
        public Prisoner Prisoner { get; set; }

        [ForeignKey("Officer")]
        public int OfficerId { get; set; }
        public Officer Officer { get; set; }
    }
}
//⦁	PrisonerId – integer, Primary Key
//⦁	Prisoner – the officer’s prisoner (required)
//⦁	OfficerId – integer, Primary Key
//⦁	Officer – the prisoner’s officer (required)
