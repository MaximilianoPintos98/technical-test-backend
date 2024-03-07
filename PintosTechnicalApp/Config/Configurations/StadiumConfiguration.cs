using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Config.Configurations;

public class StadiumConfiguration : BaseConfiguration<Stadium>
{
    public override void Configure(EntityTypeBuilder<Stadium> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(s => s.Name)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(s => s.City)
               .HasMaxLength(100);

        builder.HasOne(s => s.Team)
            .WithOne(t => t.Stadium)
            .HasForeignKey<Team>(t => t.StadiumId);
    }
}
