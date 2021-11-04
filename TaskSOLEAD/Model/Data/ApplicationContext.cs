using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSOLEAD.Model.Data
{
    class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SoleadDB;Trusted_Connection=True;");
        }
    }
}
