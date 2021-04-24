using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_MusteriTakip.Domain;
using System;

namespace mnd.Logic.BC_MusteriTakip.Data
{
    public class MusteriTakipNetsisDbContext : DbContext
    {
        public DbSet<NetsisCariEmail> NetsisCariEmails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            yol = yol.Replace("MNDAPPDB", "MND" + DateTime.Now.Year);
            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NetsisCariEmail>().ToTable("TBLCARIEMAIL");


            base.OnModelCreating(modelBuilder);
        }

    }
}
