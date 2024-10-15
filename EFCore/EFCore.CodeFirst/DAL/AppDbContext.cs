using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("sqlcon"));
        }

        // Entity Options Change Wit Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DB Table Name Change With Fluent API (DB Schema is optional)
            //modelBuilder.Entity<Product>().ToTable("ProductTable", "ProductTableSchema");

            // Haskey ile ef core'un davranışlarına uymayan propertyleri primary key olarak set edebiliyoruz
            //modelBuilder.Entity<Product>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }


        //public override int SaveChanges()
        //{
        //    ChangeTracker.Entries().ToList().ForEach(e =>
        //    {
        //        if (e.Entity is Product p)
        //        {
        //            if (e.State == EntityState.Added)
        //            {
        //                p.CreatedDate = DateTime.Now;
        //            }
        //        }
        //    });

        //    return base.SaveChanges();
        //}

    }
}
