using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Config.Configurations;

public class PlayerConfiguration : BaseConfiguration<Player>
{
    public override void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.Property(p => p.Position)
               .HasMaxLength(100);
    }
}
