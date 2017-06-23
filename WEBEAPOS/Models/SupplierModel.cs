using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using WEBEAPOS.DataAccess.DataModels;
using static WEBEAPOS.DataAccess.BusinessLayer.Utils;

namespace WEBEAPOS.Models
{
    public class SupplierModel
    {
        public TBL_SUPPLIERS Supplier { get; set; }

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

        [Display(Name = "Creado por")]
        public string CreatedBy { get; set; }

        [Display(Name = "Página Web")]
        public string WebPage { get; set; }

        [Display(Name = "Tipo de Suplidor")]
        public string SupplierType { get; set; }

        public SelectList SypplierTypeList = new SelectList(Enum.GetValues(typeof(SupplierType)).Cast<SupplierType>().ToList(), "", "");
    }
}