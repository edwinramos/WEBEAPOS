using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBEAPOS.DataAccess.DataModels;
using WEBEAPOS.DataAccess.DbContexts;

namespace WEBEAPOS.DataAccess.BusinessLayer
{
    public class ClientHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_CLIENTS> GetAll()
        {
            return Context.TBL_CLIENTS.ToList();
        }
        public TBL_CLIENTS GeById(int id)
        {            
            return Context.TBL_CLIENTS.Where(p => p.ClientId == id).FirstOrDefault();
        }
        public void Add(TBL_CLIENTS product)
        {
            Context.TBL_CLIENTS.Add(product);
            Context.SaveChanges();
        }
        public void Update(TBL_CLIENTS client)
        {
            var k = Context.TBL_CLIENTS.Where(p => p.ClientId == client.ClientId).FirstOrDefault();
            k.ClientId = client.ClientId;
            k.Name = client.Name;
            k.Email = client.Email;
            k.Address = client.Address;
            k.LastName = client.LastName;
            Context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Context.TBL_CLIENTS.Remove(Context.TBL_CLIENTS.Where(p => p.ClientId == Id).FirstOrDefault());
            Context.SaveChanges();
        }
    }
}
