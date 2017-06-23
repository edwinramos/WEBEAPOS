using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBEAPOS.DataAccess.DataModels;

namespace WEBEAPOS.DataAccess.DbContexts
{
    public class EAPOSDBContext: DbContext
    {
        public DbSet<TBL_PRODUCTS> TBL_PRODUCTS { get; set; }
        public DbSet<TBL_BILLS> TBL_BILLS { get; set; }
        public DbSet<TBL_BILLDETAILS> TBL_BILLDETAILS { get; set; }
        public DbSet<TBL_SUPPLIERS> TBL_SUPPLIERS { get; set; }
        public DbSet<TBL_CLIENTS> TBL_CLIENTS { get; set; }
        public DbSet<TBL_BRANCHES> TBL_BRANCHES { get; set; }
        public DbSet<TBL_TAXES> TBL_TAXES { get; set; }
        public DbSet<TBL_BRANCH_PRODUCTS> TBL_BRANCH_PRODUCTS { get; set; }
        public DbSet<TBL_USERS> TBL_USERS { get; set; }
    }
}
