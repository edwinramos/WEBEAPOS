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
    public class TBL_BRANCHES
    {
        [Key]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchId { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }        

        public string CreatedBy { get; set; }

        [DefaultValue(1)]
        public int TaxId { get; set; }
        public virtual TBL_TAXES Taxes { get; set; }

        public virtual List<TBL_BRANCH_PRODUCTS> Branches { get; set; }
    }
}
