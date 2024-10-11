using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DatabaseFirst.DAL
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext()
        {

        }


        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbContextInitializer.configuration.GetConnectionString("sqlcon"));
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Product> Products { get; set; }


    }
}
