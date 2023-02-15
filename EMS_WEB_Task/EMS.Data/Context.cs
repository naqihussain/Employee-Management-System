using EMS.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace EMS.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(WebUtil.Context);
            optionsBuilder.UseSqlServer(WebUtil.Context, options => options.EnableRetryOnFailure());

        }
        //public Context(DbContextOptions<Context> options) : base(options)
        //{

        //}
        //public Context()
        //{
        //    this.ChangeTracker.LazyLoadingEnabled = false;
        //    //this.Database.SetCommandTimeout = 60;
        //    Database.SetCommandTimeout(150000);
        //}
        public virtual DbSet<Department>? Department { get; set; }
        public DbSet<Employee>? Employees { get; set; }
    }
}