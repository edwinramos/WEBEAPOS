using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBEAPOS.DataAccess.DataModels
{
    public class TBL_BRANCH_PRODUCTS
    {
        [DefaultValue(0)]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Key, Column(Order = 0)]
        public int BranchId { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
    }
}
