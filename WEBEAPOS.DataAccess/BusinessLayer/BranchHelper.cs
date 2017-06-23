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
    public class BranchHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_BRANCHES> GetAll()
        {
            return Context.TBL_BRANCHES.ToList();
        }
        public TBL_BRANCHES GetById(int id)
        {            
            return Context.TBL_BRANCHES.Where(p => p.BranchId == id).FirstOrDefault();
        }
        public void Add(TBL_BRANCHES obj)
        {
            Context.TBL_BRANCHES.Add(obj);
            Context.SaveChanges();
        }
        public void Update(TBL_BRANCHES obj)
        {
            var k = Context.TBL_BRANCHES.Where(p => p.BranchId == obj.BranchId).FirstOrDefault();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TBL_BRANCHES, TBL_BRANCHES>();
            });

            Mapper.Map(obj, k);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Context.TBL_BRANCHES.Remove(Context.TBL_BRANCHES.Where(p => p.TaxId == id).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
