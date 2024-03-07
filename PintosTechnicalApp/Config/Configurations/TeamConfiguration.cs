using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Config.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(100); 

        builder.Property(t => t.City)
               .HasMaxLength(100);

        builder.HasOne(t => t.Trainer)
               .WithOne(tr => tr.Team)
               .HasForeignKey<Trainer>(tr => tr.TeamId);

        builder.HasMany(t => t.Players)
                 .WithOne(p => p.Team)
                 .HasForeignKey(p => p.TeamId);
    }
}
