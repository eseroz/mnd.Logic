using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mnd.Logic.Model.Satis;

namespace mnd.Logic.Persistence.Configurations
{
    public class SiparisConfig : IEntityTypeConfiguration<Siparis>
    {
        public void Configure(EntityTypeBuilder<Siparis> builder)
        {
            builder.ToTable(nameof(Siparis), "Satis");

            builder
                .Metadata
                .FindNavigation(nameof(Siparis.SiparisKalemleri))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
              .HasMany(c => c.SiparisKalemleri)
              .WithOne(c => c.SiparisNav)
              .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.OdemeBankaKodNavigation)
                .WithMany()
                .HasForeignKey(c => c.OdemeBankaKod)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.CariKartNavigation)
                .WithMany()
                .HasForeignKey(c => c.CariKod)
                .OnDelete(DeleteBehavior.Restrict);






            builder
                .HasOne(c => c.TeslimTipKodNavigation)
                .WithMany(p => p._Siparis)
                .HasForeignKey(c => c.TeslimTipKod)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.SatisTipKodNavigation)
                .WithMany(p => p._Siparis)
                .HasForeignKey(c => c.SatisTipKod)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.OdemeTipKodNavigation)
                .WithMany(p => p._Siparis)
                .HasForeignKey(c => c.OdemeTipKod)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.FaturaDovizTipKodNavigation)
                .WithMany()
                .HasForeignKey(c => c.FaturaDovizTipKod)
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(c => c.TakipDovizTipKodNavigation)
              .WithMany()
              .HasForeignKey(c => c.TakipDovizTipKod)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}