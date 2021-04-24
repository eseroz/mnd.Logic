using Microsoft.EntityFrameworkCore;
using mnd.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Dashboard
{
    public class MaliyetDbContext : DbContext
    {
        public DbSet<Exw> ExwRapor { get; set; }

     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var path = GlobalSettings.Default.SqlCnnString;
                optionsBuilder.UseSqlServer(path);
                optionsBuilder.EnableDetailedErrors(true);
                base.OnConfiguring(optionsBuilder);
            }

            optionsBuilder.EnableDetailedErrors(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exw>().ToTable("Exw", "Maliyet");


            base.OnModelCreating(modelBuilder);
        }

    }
}

