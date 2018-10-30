using MvvmLight4EF.Data.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.Data.Entities
{
    public class EzReadContext : DbContext
    {
        //public EzReadContext(string connectionString) : base(connectionString)
        //{
        //    //in the constructor of our context we need to set database initializer to null
        //    //we don't want Entity Framework to create the database, we just want to access it.
        //    Database.SetInitializer<EzReadContext>(null);
        //}
        ~EzReadContext()
        {
            this.Dispose();
        }

        public DbSet<Patient> Patients { set; get; }

        public DbSet<Record> Records { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
