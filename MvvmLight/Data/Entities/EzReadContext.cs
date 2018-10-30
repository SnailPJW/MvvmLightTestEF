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
        //~EzReadContext()
        //{
        //    this.Dispose();
        //}
        public EzReadContext() : base("name = DefaultEntity")
        {
            //this.Dispose();
            //Database.SetInitializer<EzReadContext>(null);
            AppDomain.CurrentDomain.SetData("DataDirectory",
              System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "../../App_Data"));
            //System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory) 取得目前執行檔的所在目錄
            //Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            //CommonApplicationData 目录，它用作所有用户使用的应用程序特定数据的公共储存库(C:\ProgramData\)。ref : https://blog.csdn.net/swort_177/article/details/4580359
        }

        public DbSet<Patient> Patients { set; get; }

        public DbSet<Record> Records { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
