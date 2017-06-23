using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBEAPOS.DataAccess.DataModels;
using WEBEAPOS.DataAccess.DbContexts;

namespace WEBEAPOS.DataAccess.BusinessLayer
{
    public class SupplierHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_SUPPLIERS> GetAll()
        {
            return Context.TBL_SUPPLIERS.ToList();
        }
        public TBL_SUPPLIERS GetById(int id)
        {            
            return Context.TBL_SUPPLIERS.Where(p => p.SupplierId == id).FirstOrDefault();
        }
        public void Add(TBL_SUPPLIERS supplier)
        {
            Context.TBL_SUPPLIERS.Add(supplier);
            Context.SaveChanges();
        }
        public void Update(TBL_SUPPLIERS supplier)
        {
            var obj = Context.TBL_SUPPLIERS.Where(p => p.SupplierId == supplier.SupplierId).FirstOrDefault();
            obj.Name = supplier.Name;
            obj.PhoneNumber = supplier.PhoneNumber;
            obj.ContactName = supplier.ContactName;
            obj.ContactTitle = supplier.ContactTitle;
            obj.ContactPhone = supplier.ContactPhone;
            obj.Description = supplier.Description;
            obj.Email = supplier.Email;
            obj.SupplierId = supplier.SupplierId;
            obj.SupplierType = supplier.SupplierType;
            obj.WebPage = supplier.WebPage;
            obj.City = supplier.City;
            obj.Address = supplier.Address;
            Context.SaveChanges();
        }
        public void Delete(int sId)
        {
            Context.TBL_SUPPLIERS.Remove(Context.TBL_SUPPLIERS.Where(p => p.SupplierId == sId).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
