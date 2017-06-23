using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBEAPOS.DataAccess.DataModels
{
    public class TBL_SUPPLIERS
    {
        [Key]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Nombre de Contacto")]
        public string ContactName { get; set; }

        [Display(Name = "Telefono de Contacto")]
        public string ContactPhone { get; set; }

        [Display(Name = "Titulo de Contacto")]
        public string ContactTitle { get; set; }

        public string Email { get; set; }

        public string CreatedBy { get; set; }

        [Display(Name = "Página Web")]
        public string WebPage { get; set; }

        [Display(Name = "Tipo de Suplidor")]
        public string SupplierType { get; set; }
    }
}
