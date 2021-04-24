using Microsoft.EntityFrameworkCore;
using mnd.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Sikayet
{
    public class _SikayetDbContext : DbContext
    {
        public DbSet<Sikayet> Sikayetler { get; set; }
        public DbSet<SikayetKonuKategori> KonuKategorileri { get; set; }
        public DbSet<SikayetBolum> SikayetBolumleri { get; set; }



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
            modelBuilder.HasDefaultSchema("Satis");

            modelBuilder.Entity<Sikayet>().ToTable(nameof(Sikayet));
            modelBuilder.Entity<SikayetBolum>().ToTable(nameof(SikayetBolum));
            modelBuilder.Entity<SikayetKonuKategori>().ToTable(nameof(SikayetKonuKategori));


            base.OnModelCreating(modelBuilder);
        }
    }
}
