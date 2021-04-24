using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_Satis.Domain;
using mnd.Logic.BC_Satis._Sikayet;
using mnd.Logic.BC_Satis._Teklif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mnd.Logic.BC_Satis._Siparis.Entities;

namespace mnd.Logic.BC_Satis.Data
{
    public class _SatisDbContext : DbContext
    {
        public DbSet<Teklif> Teklifler { get; set; }

        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<Sikayet> Sikayetler { get; set; }

        public DbSet<Siparis> Siparisler { get; set; }


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
            modelBuilder.Entity<Teklif>().ToTable(nameof(Teklif));
            modelBuilder.Entity<Musteri>().ToTable("PandapCari");
            modelBuilder.Entity<Sikayet>().ToTable("Sikayet");
            modelBuilder.Entity<Siparis>().ToTable("Siparis");
            base.OnModelCreating(modelBuilder);
        }
    }
}
