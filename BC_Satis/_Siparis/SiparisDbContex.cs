using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_Satis._Siparis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Siparis
{
    public class SiparisDbContex : DbContext
    {
        public DbSet<Siparis> Siparisler { get; set; }
        public  DbSet<CariKart> CariKartlar { get; set; }


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
            modelBuilder.Entity<CariKart>().ToTable("CariKart","Netsis");
            modelBuilder.HasDefaultSchema("Satis");

            modelBuilder.Entity<Siparis>().ToTable(nameof(Siparis));

           

            base.OnModelCreating(modelBuilder);
        }
    }
}
