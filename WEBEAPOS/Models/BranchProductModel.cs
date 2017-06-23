using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBEAPOS.DataAccess.DataModels;

namespace WEBEAPOS.Models
{
    public class BranchProductModel
    {
        public TBL_BRANCHES Branch { get; set; }

        [Required]
        public int BranchId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Cantidad")]
        public int? Quantity { get; set; }
    }
}