using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PintosTechnicalApp.Config.Configurations;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Interfaces;

namespace PintosTechnicalApp.Config;

public class AppDbContext : DbContext, IAppDbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
    {
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Trainer> Trainers { get; set; }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        => await Database.BeginTransactionAsync();

    public async Task<int> SaveChangesAsync()
    {
        foreach (var entry in ChangeTracker.Entries<GenericEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:

                    entry.Entity.Created = DateTime.Now;
                    entry.Entity.Enabled = true;
                    break;
                case EntityState.Deleted:
                    entry.Entity.Enabled = false;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        var result = await base.SaveChangesAsync();

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StadiumConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
    }
}
