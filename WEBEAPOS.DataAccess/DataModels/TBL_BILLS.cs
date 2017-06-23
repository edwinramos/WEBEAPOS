using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBEAPOS.DataAccess.DataModels
{
    public class TBL_BILLS
    {
        [Key]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }
        
        public DateTime BillDate { get; set; }

        public Double TotalAmout { get; set; }

        public string CreatedBy { get; set; }

        public int ClientId { get; set; }
        public virtual TBL_CLIENTS Cliente { get; set; }

        public int BillDetailId { get; set; }
        public virtual List<TBL_BILLDETAILS> BillDetails { get; set; }
    }
}
