using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_Uretim.SH_RotaModel;
using mnd.Logic.Model.Uretim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class UretimDbContext:DbContext
    {
        public DbSet<Uretim_UretimTablo> UretimTablo { get; set; }

        public DbSet<MakinaParca> MakinaParcalari { get; set; }
        public DbSet<MakinaDurusTanim> MakinaDurusTanimlar { get; set; }

        public DbSet<MakinaAktiviteKayit> MakinaAktiviteKayits { get; set; }

        public DbSet<UretimEmri> UretimEmirleri { get; set; }

        public DbSet<UretimEmriRulo> UretimEmriRulolar { get; set; }

        public DbSet<Anakart> Anakartlar { get; set; }

        public DbSet<ShRecete> ShReceteler { get; set; }


        public  DbSet<ShRotaKart> ShRotaKartlari { get; set; }
        public  DbSet<ShRotaKartDokumBobin> ShRotaKartDokumBobinleri { get; set; }
        public  DbSet<ShRotaKartFaz> ShRotaKartFazlari { get; set; }
        public  DbSet<ShRotaKartFazOperasyon> ShRotaKartFazOperasyonlari { get; set; }



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
            modelBuilder.Entity<Uretim_UretimTablo>().ToTable("UretimTablo", "Uretim");

           
            modelBuilder.Entity<MakinaDurusTanim>().ToTable(nameof(MakinaDurusTanim), "Uretim");

            modelBuilder.Entity<MakinaParca>().ToTable("MakinaParca", "Uretim");

            modelBuilder.Entity<UretimEmri>().ToTable(nameof(UretimEmri), "Uretim");
            modelBuilder.Entity<Anakart>().ToTable("AnaKart", "Uretim");

            modelBuilder.Entity<UretimEmriRulo>().ToTable(nameof(UretimEmriRulo), "Uretim");

            modelBuilder.Entity<MakinaAktiviteKayit>().ToTable(nameof(MakinaAktiviteKayit), "Uretim");


            base.OnModelCreating(modelBuilder);
        }

    }
}
