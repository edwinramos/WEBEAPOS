using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBEAPOS.Models
{
    public class BranchModel
    {
        [Required]
        public int BranchId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Display(Name = "Calle")]
        public string Street { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Código Postal")]
        public string ZipCode { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }

        [Display(Name = "Creado por")]
        public string CreatedBy { get; set; }

        [Display(Name = "Impuestos")]
        [DefaultValue(1)]
        public int TaxId { get; set; }

        public bool Tax = true;
    }
}