using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using SpaStore.Data.Configurations;
using SpaStore.Model;

namespace SpaStore.Data
{
    public class EfDbContext :DbContext
    {
        static EfDbContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        public EfDbContext()
            : base(nameOrConnectionString: "SportsStore")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ImageConfiguration());
        }

        public override int SaveChanges()
        {
            ApplyRules();
            return base.SaveChanges();
        }

        private void ApplyRules()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added)
                    e.CreatedDate = DateTime.Now;

                e.ModifiedDate = DateTime.Now;
            }
        }
    }
}