using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBEAPOS.DataAccess.DataModels
{
    public class TBL_PRODUCTS
    {
        [Key]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Barcode { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public Double SupplierPrice { get; set; }

        public Double MarginPercentage { get; set; }

        public Double FinalPrice { get; set; }

        public DateTime BuyDate { get; set; }

        public string Brand { get; set; }

        public string CreatedBy { get; set; }

        public virtual List<TBL_BRANCH_PRODUCTS> Branches { get; set; }

        public int SupplierId { get; set; }
        public virtual TBL_SUPPLIERS Supplier { get; set; }              
    }
}
