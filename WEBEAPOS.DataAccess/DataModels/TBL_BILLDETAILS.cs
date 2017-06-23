using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBEAPOS.DataAccess.DataModels
{
    public class TBL_BILLDETAILS
    {
        [Key]
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillDetailId { get; set; }

        public int Quantity { get; set; }
        public Double QuantityPrice { get; set; }
        public Double Discount { get; set; }
        public Double DiscountPrice { get; set; }

        public int ProductId { get; set; }
        public virtual TBL_PRODUCTS Product{ get; set; }

        public int BillId { get; set; }
        public virtual TBL_BILLS Bill { get; set; }
    }
}
