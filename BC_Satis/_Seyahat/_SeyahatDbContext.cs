using Microsoft.EntityFrameworkCore;
using mnd.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis._Seyahat
{
    public class _SeyahatDbContext:DbContext
    {
        public DbSet<Seyahat> Seyahatler { get; set; }
        public DbSet<SeyahatGorusme> SeyahatGorusmes { get; set; }
        public DbSet<UlkeSabit> UlkeSabits { get; set; }

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

            modelBuilder.Entity<Seyahat>().ToTable(nameof(Seyahat));
            modelBuilder.Entity<SeyahatGorusme>().ToTable(nameof(SeyahatGorusme));
            modelBuilder.Entity<UlkeSabit>().ToTable(nameof(UlkeSabit),"App");


            base.OnModelCreating(modelBuilder);
        }
    }
}
