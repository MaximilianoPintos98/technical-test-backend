using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Interfaces;

public interface IAppDbContext
{
    public DbSet<Team> Teams { get; set; }   
    public DbSet<Player> Players { get; set; }   
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Trainer> Trainers { get; set; }

    Task<int> SaveChangesAsync();

    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
