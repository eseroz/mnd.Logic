using Microsoft.EntityFrameworkCore;
using mnd.Common;

namespace mnd.Logic.BC_Personel
{
    public class PersonelDbContext : DbContext
    {
        public DbSet<PersonelBilgi> Personeller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Personel");

            modelBuilder.Entity<PersonelBilgi>().ToTable(nameof(PersonelBilgi));


            base.OnModelCreating(modelBuilder);
        }
    }
}
