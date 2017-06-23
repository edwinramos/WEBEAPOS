using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBEAPOS.DataAccess.DataModels;
using WEBEAPOS.DataAccess.DbContexts;

namespace WEBEAPOS.DataAccess.BusinessLayer
{
    public class BillDetailHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_BILLDETAILS> GetAll()
        {
            return Context.TBL_BILLDETAILS.ToList();
        }
        public TBL_BILLDETAILS GetById(int id)
        {
            return Context.TBL_BILLDETAILS.Where(p => p.BillDetailId == id).FirstOrDefault();
        }
        public void Add(TBL_BILLDETAILS product)
        {
            Context.TBL_BILLDETAILS.Add(product);
            Context.SaveChanges();
        }
        public void Update(TBL_BILLDETAILS billDetail)
        {
            var k = Context.TBL_BILLDETAILS.Where(p => p.BillDetailId == billDetail.BillDetailId).FirstOrDefault();
            k.BillDetailId = billDetail.BillDetailId;
            k.BillId = billDetail.BillId;
            k.ProductId = billDetail.ProductId;
            k.Quantity = billDetail.Quantity;
            k.QuantityPrice = billDetail.QuantityPrice;
            k.DiscountPrice = billDetail.DiscountPrice;
            k.Discount = billDetail.Discount;
            Context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Context.TBL_BILLDETAILS.Remove(Context.TBL_BILLDETAILS.Where(p => p.BillDetailId == Id).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
