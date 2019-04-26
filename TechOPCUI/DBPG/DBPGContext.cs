using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TechOPCUI.DBPG
{
    class DBPGContext : DbContext
    {
        #region properties
        public DbSet<CapacityDB> CapacityDb { get; set; } // коллекция обьектов типа CapacityDB
        public DbSet<DensityDB> DensityDb { get; set; }   // коллекция обьектов типа DensityDB
        #endregion

        #region constructor
        public DBPGContext() : base(nameOrConnectionString: "Default")
        {
        }
        #endregion

        #region methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("Connection Established");
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Убирает добавление буквы s в конец названия таблицы
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
