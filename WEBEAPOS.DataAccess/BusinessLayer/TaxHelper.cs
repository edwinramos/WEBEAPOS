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
    public class TaxHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_TAXES> GetAll()
        {
            return Context.TBL_TAXES.ToList();
        }
        public TBL_TAXES GetById(int id)
        {
            return Context.TBL_TAXES.Where(p => p.TaxId == id).FirstOrDefault();
        }
        public void Save(TBL_TAXES obj)
        {
            var k = Context.TBL_TAXES.Where(p => p.TaxId == obj.TaxId).FirstOrDefault();
            if (k == null)
            {
                Context.TBL_TAXES.Add(obj);
            }
            else
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<TBL_TAXES, TBL_TAXES>();
                });

                Mapper.Map(obj, k);
            }
            Context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Context.TBL_TAXES.Remove(Context.TBL_TAXES.Where(p => p.TaxId == Id).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
