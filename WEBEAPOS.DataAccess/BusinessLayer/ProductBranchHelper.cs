using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBEAPOS.DataAccess.DataModels;
using WEBEAPOS.DataAccess.DbContexts;

namespace WEBEAPOS.DataAccess.BusinessLayer
{
    public class ProductBranchHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_BRANCH_PRODUCTS> GetAll()
        {
            return Context.TBL_BRANCH_PRODUCTS.ToList();
        }
        public TBL_BRANCH_PRODUCTS GetById(int branchId, int productId)
        {            
            return Context.TBL_BRANCH_PRODUCTS.Where(p => p.BranchId == branchId && p.ProductId == productId).FirstOrDefault();
        }
        public void Save(TBL_BRANCH_PRODUCTS obj)
        {
            var k = Context.TBL_BRANCH_PRODUCTS.Where(p => p.BranchId == obj.BranchId && p.ProductId == obj.ProductId).FirstOrDefault();
            if (k == null)
            {
                Context.TBL_BRANCH_PRODUCTS.Add(obj);
            }
            else
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<TBL_BRANCH_PRODUCTS, TBL_BRANCH_PRODUCTS>();
                });

                Mapper.Map(obj, k);
            }
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Context.TBL_BRANCH_PRODUCTS.Remove(Context.TBL_BRANCH_PRODUCTS.Where(p => p.BranchId == id).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
