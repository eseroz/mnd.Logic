using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mnd.Logic.Model.Uretim;

namespace mnd.Logic.Persistence.Configurations
{
    public class UretimEmriConfig : IEntityTypeConfiguration<UretimEmri>
    {
        public void Configure(EntityTypeBuilder<UretimEmri> builder)
        {
            builder.ToTable(nameof(UretimEmri), "Uretim");

            builder
             .HasMany(c => c.UretimBobinler)
             .WithOne(p => p.UretimEmriKodNav)
             .HasForeignKey(k => k.UretimEmriKod)
             .OnDelete(DeleteBehavior.Cascade);

            builder
                 .HasMany(c => c.UretimPaletler)
                 .WithOne(p => p.UretimEmriKodNav)
                 .HasForeignKey(k => k.UretimEmriKod)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasMany(c => c.PlanlamaRulolari)
              .WithOne(p => p.UretimEmriKodNav)
              .HasForeignKey(k => k.UretimEmriKod)
              .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasMany(c => c.MakineAsamalari1)
              .WithOne(p => p.UretimEmriKodNav)
              .HasForeignKey(k => k.UretimEmriKod)
              .OnDelete(DeleteBehavior.Cascade);

            builder
             .HasMany(c => c.MakineAsamalari2)
             .WithOne(p => p.UretimEmriKodNav)
             .HasForeignKey(k => k.UretimEmriKod)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}