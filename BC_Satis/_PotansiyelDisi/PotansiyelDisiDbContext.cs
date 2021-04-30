using Microsoft.EntityFrameworkCore;
using mnd.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._PotansiyelDisi
{
    public class PotansiyelDisiDbContext:DbContext
    {
        public DbSet<PotansiyelDisiMusteri> PostansiyelDisiMusteris { get; set; }
        public DbSet<PotansiyelDisiMusteriArama> PostansiyelDisiMusteriAramas { get; set; }
        public DbSet<P_UlkeSabit> UlkeSabits { get; set; }

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
            modelBuilder.Entity<PotansiyelDisiMusteri>().ToTable(nameof(PotansiyelDisiMusteri));
            modelBuilder.Entity<PotansiyelDisiMusteriArama>().ToTable(nameof(PotansiyelDisiMusteriArama));
            modelBuilder.Entity<P_UlkeSabit>().ToTable("UlkeSabit", "App");

            modelBuilder.Entity<PotansiyelDisiMusteriArama>()
            .HasOne(p => p.PotansiyelDisiMusteri)
            .WithMany(b => b.PotansiyelDisiMusteriArama);

            base.OnModelCreating(modelBuilder);
        }
    }
}