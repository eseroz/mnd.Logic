using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mnd.Logic.Model.Uretim;

namespace mnd.Logic.Persistence.Configurations
{
    public class BobinConfig : IEntityTypeConfiguration<Bobin>
    {
        public void Configure(EntityTypeBuilder<Bobin> builder)
        {
            builder.ToTable(nameof(Bobin), "Uretim");


        }
    }
}