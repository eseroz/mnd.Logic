using Microsoft.EntityFrameworkCore;
using mnd.Common;
using System.Collections.Generic;

namespace mnd.Logic.Model.Operasyon
{
    public class OperasyonDbContext : DbContext
    {
        public DbSet<Irsaliye> CariIrsaliyeler { get; set; }
        public DbSet<IrsaliyePalet> CariIrsaliyePaletler { get; set; }
        public DbSet<SevkiyatEmri> SevkiyatEmirleri { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GlobalSettings.Default.SqlCnnString);
                optionsBuilder.EnableDetailedErrors(true);
                base.OnConfiguring(optionsBuilder);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
