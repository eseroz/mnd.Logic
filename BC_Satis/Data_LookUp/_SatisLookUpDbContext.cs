using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_Satis.Data_LookUp.Model;
using mnd.Logic.Model.Stok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Satis.Data_LookUp
{
    public class _SatisLookUpDbContext: DbContext
    {
        public DbSet<OdemeTip> OdemeTipleri { get; set; }
        public DbSet<SatisTip> SatisTipleri { get; set; }
        public DbSet<LmeTip> LmeTipleri { get; set; }
        public DbSet<TeslimTip> TeslimTipleri { get; set; }
        public DbSet<BirimTip> BirimTipleri { get; set; }
        public DbSet<DovizTip> DovizTipleri { get; set; }
        public DbSet<GumrukTip> GumrukTipleri { get; set; }



        public DbSet<AlasimTip> AlasimTipleri { get; set; }
        public DbSet<AmbalajTip> AmbalajTipleri { get; set; }
        public DbSet<KulcePrimTip> KulcePrimTipleri { get; set; }
        public DbSet<KullanimAlanTip> KullanimAlanTipleri { get; set; }
        public DbSet<MasuraTip> MasuraTipleri { get; set; }
        public DbSet<SertlikTip> SertlikTipleri { get; set; }
        public DbSet<YuzeyTip> YuzeyTipleri { get; set; }

        public DbSet<TBLIHRSTK> Urunler { get; set; }
        public DbSet<TasimaSekli> TasimaSekilleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var path = GlobalSettings.Default.SqlCnnString;
                optionsBuilder.UseSqlServer(path);
                optionsBuilder.EnableDetailedErrors(true);
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("_Ref");


            modelBuilder.Entity<BirimTip>().ToTable(nameof(BirimTip));
            modelBuilder.Entity<DovizTip>().ToTable(nameof(DovizTip));
            modelBuilder.Entity<LmeTip>().ToTable(nameof(LmeTip));
            modelBuilder.Entity<OdemeTip>().ToTable(nameof(OdemeTip));
            modelBuilder.Entity<SatisTip>().ToTable(nameof(SatisTip));
            modelBuilder.Entity<GumrukTip>().ToTable(nameof(GumrukTip));

            

            modelBuilder.Entity<AlasimTip>().ToTable(nameof(AlasimTip));
            modelBuilder.Entity<AmbalajTip>().ToTable(nameof(AmbalajTip));
            modelBuilder.Entity<KulcePrimTip>().ToTable(nameof(KulcePrimTip));
            modelBuilder.Entity<KullanimAlanTip>().ToTable(nameof(KullanimAlanTip));
            modelBuilder.Entity<MasuraTip>().ToTable(nameof(MasuraTip));

            modelBuilder.Entity<SertlikTip>().ToTable(nameof(SertlikTip));
            modelBuilder.Entity<TeslimTip>().ToTable(nameof(TeslimTip));
            modelBuilder.Entity<YuzeyTip>().ToTable(nameof(YuzeyTip));


            modelBuilder.Entity<TBLIHRSTK>().ToTable(nameof(TBLIHRSTK));
            modelBuilder.Entity<TasimaSekli>().ToTable(nameof(TasimaSekli));

            base.OnModelCreating(modelBuilder);
        }
    }
}

