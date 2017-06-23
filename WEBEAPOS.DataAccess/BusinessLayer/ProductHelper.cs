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
    public class ProductHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_PRODUCTS> GetAll()
        {
            return Context.TBL_PRODUCTS.ToList();
        }
        public TBL_PRODUCTS GetById(int id)
        {
            Context.Configuration.ProxyCreationEnabled = false;
            return Context.TBL_PRODUCTS.Where(p => p.ProductId == id).FirstOrDefault();
        }
        public void Add(TBL_PRODUCTS product)
        {
            Context.TBL_PRODUCTS.Add(product);
            Context.SaveChanges();
        }
        public void Update(TBL_PRODUCTS obj)
        {
            var k = Context.TBL_PRODUCTS.Where(p => p.ProductId == obj.ProductId).FirstOrDefault();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TBL_PRODUCTS, TBL_PRODUCTS>();
            });

            Mapper.Map(obj, k);

            Context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Context.TBL_PRODUCTS.Remove(Context.TBL_PRODUCTS.Where(p => p.ProductId == Id).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
