using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBEAPOS.DataAccess.DataModels
{
    public class TBL_TAXES
    {
        [Key]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxId { get; set; }

        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Display(Name = "Porcentaje")]
        public double Percentage { get; set; }

        public string CreatedBy { get; set; }
    }
}