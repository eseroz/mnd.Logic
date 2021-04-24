using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mnd.Logic.Model.Uretim;

namespace mnd.Logic.Persistence.Configurations
{
    public class PaletConfig : IEntityTypeConfiguration<Palet>
    {
        public void Configure(EntityTypeBuilder<Palet> builder)
        {
            builder.ToTable(nameof(Palet), "Uretim");

            builder
           .HasMany(c => c.Bobinler)
           .WithOne(c => c.PaletIdNav)
           .OnDelete(DeleteBehavior.Cascade);

            builder
             .HasOne(c => c.CariKartNav)
             .WithMany()
             .HasForeignKey(k => k.CariKod);



        }
    }
}