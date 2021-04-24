using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_Dokum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Dokum.Data
{
    public class DokumDbContext:DbContext
    {
        public DbSet<DokumBobin> DokumBobinleri { get; set; }

        public DbSet<DokumBobinIslemAdim> DokumBobinIslemAdimlari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Uretim");

            modelBuilder.Entity<DokumBobin>().ToTable(nameof(DokumBobin));
            modelBuilder.Entity<DokumBobinIslemAdim>().ToTable(nameof(DokumBobinIslemAdim));


            base.OnModelCreating(modelBuilder);
        }
    }
}
