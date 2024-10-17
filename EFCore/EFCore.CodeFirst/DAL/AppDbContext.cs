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
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("sqlcon"));
        }

        // Entity Options Change With Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DB Table Name Change With Fluent API (DB Schema is optional)
            //modelBuilder.Entity<Product>().ToTable("ProductTable", "ProductTableSchema");

            // Haskey ile ef core'un davranışlarına uymayan propertyleri primary key olarak set edebiliyoruz
            //modelBuilder.Entity<Product>().HasKey(x => x.Id);

            // Relations with fluent api

            // One to Many
            // Category entity'sinin birden fazla (HasMany) product'ı olabilir, product entity'sinin bir adet categorisi olabilir (WithOne),
            // ForeignKey product tablsundaki CategoryId property'si
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);


            // One to One
            // bire bir ilişkiyi fluent api ile kullanırsak EFCore'un parent child ilişkisini kurabilmesi için foreign key alanında tür belirtmemiz gerekiyor
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductId);

            // bire bir ilişki best practices
            // Bire bir ilişkideki id ve foreign key alanları yerine id alanını foreign key olarak tanımlayabilir bu daha doğru bir yol olur
            // Eğer Böyle yaparsak ProductFeatures entity'sinde productId navigation property'sine ihtiyacımız olmaz
            // UYARI eğer bu yolu izleyeceksek id alanında otomatik artan özelliğinin kapalı olması lazım ef core bunu kendisi ayarlıyor
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

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
