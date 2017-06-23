using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBEAPOS.DataAccess.DataModels;
using WEBEAPOS.DataAccess.DbContexts;

namespace WEBEAPOS.DataAccess.BusinessLayer
{
    public class BillHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_BILLS> GetBills()
        {
            return Context.TBL_BILLS.ToList();
        }
        public TBL_BILLS GetBillById(int id)
        {
            return Context.TBL_BILLS.Where(p => p.BillId == id).FirstOrDefault();
        }
        public void AddBill(TBL_BILLS bill)
        {
            Context.TBL_BILLS.Add(bill);
            Context.SaveChanges();
        }
        public void UpdateBill(TBL_BILLS bill)
        {
            var obj = Context.TBL_BILLS.Where(p => p.BillId == bill.BillId).FirstOrDefault();
            obj.BillId = bill.BillId;
            obj.BillDate = bill.BillDate;
            obj.TotalAmout = bill.TotalAmout;
            obj.BillDetailId = bill.BillDetailId;
            obj.ClientId = bill.ClientId;
            Context.SaveChanges();
        }
        public void DeleteBill(int sId)
        {
            Context.TBL_BILLS.Remove(Context.TBL_BILLS.Where(p => p.BillId == sId).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
