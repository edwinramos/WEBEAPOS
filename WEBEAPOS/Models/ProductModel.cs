using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBEAPOS.DataAccess.DataModels;

namespace WEBEAPOS.Models
{
    public class ProductModel
    {
        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Código de Barras")]
        public string Barcode { get; set; }

        [Display(Name = "Nombre")]
        public string ProductName { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Precio de Suplidor")]
        public Double SupplierPrice { get; set; }

        [Display(Name = "Margen(%)")]
        public Double MarginPercentage { get; set; }

        [Display(Name = "Precio Final")]
        public Double FinalPrice { get; set; }

        [Display(Name = "Fecha de Compra")]
        public DateTime BuyDate { get; set; }

        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Suplidor")]
        public int SupplierId { get; set; }

        [Display(Name = "Creado por")]
        public string CreatedBy { get; set; }

        public List<TBL_SUPPLIERS> SupplierList { get; set; }

        public List<TBL_BRANCHES> Branches { get; set; }

        public List<TBL_BRANCH_PRODUCTS> ProductInBranches { get; set; }

        public List<BranchProductModel> BranchsProducts { get; set; }
    }
}