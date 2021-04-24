using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mnd.Logic.Model.Satis;

namespace mnd.Logic.Persistence.Configurations
{
    public class SiparisKalemConfig : IEntityTypeConfiguration<SiparisKalem>
    {
        public void Configure(EntityTypeBuilder<SiparisKalem> builder)
        {
            builder.ToTable(nameof(SiparisKalem), "Satis");

            //builder
            //  .HasMany(c => c.UretimEmirleri)
            //  .WithOne(p => p.SiparisKalemKodNav)
            //  .HasForeignKey(c => c.SiparisKalemKod)
            //  .OnDelete(DeleteBehavior.Cascade);


            //builder.HasMany(c => c.Paletler)
            //    .WithOne(c => c.FiyatKalemKodNav)
            //    .HasForeignKey(c => c.FiyatKalemKod)
            //    .HasPrincipalKey(c => c.SiparisKalemKod);



            //builder
            //     .HasOne(c => c.LmeTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.LmeTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //builder
            //     .HasOne(c => c.BirimTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.BirimTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //----------------

            //builder
            //     .HasOne(c => c.UrunKodNavigation)
            //     .WithMany(p => p.SiparisKalem)
            //     .HasForeignKey(c => c.UrunKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //builder
            //     .HasOne(c => c.AlasimTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.AlasimTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //builder
            //     .HasOne(c => c.AmbalajTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.AmbalajTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);



            //builder
            //     .HasOne(c => c.KullanimAlanTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.KullanimAlanTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //builder
            //     .HasOne(c => c.MasuraTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.MasuraTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //builder
            //     .HasOne(c => c.SertlikTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.SertlikTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //builder
            //     .HasOne(c => c.YuzeyTipKodNavigation)
            //     .WithMany(p => p._SiparisKalem)
            //     .HasForeignKey(c => c.YuzeyTipKod)
            //     .OnDelete(DeleteBehavior.Restrict);

            //----------------------------------------------------------------

            //builder
            //     .HasMany(c => c.UretimEmirleri)
            //     .WithOne(p => p.SiparisKalemKodNav)
            //     .HasForeignKey(c => c.SiparisKalemKod)
            //     .OnDelete(DeleteBehavior.Cascade);


            //// netsis faturamiktarı sorgusu
            //builder
            //  .HasMany(c => c.FaturasiKesilenler_Kg)
            //  .WithOne(c => c.SiparisKalemNav)
            // .HasForeignKey(c => c.SiparisKalemKod)
            // .OnDelete(DeleteBehavior.Restrict);
        }
    }
}