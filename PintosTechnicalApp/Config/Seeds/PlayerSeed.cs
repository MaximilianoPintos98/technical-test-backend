using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Config.Seeds;

public class PlayerSeed
{
    public static async Task AddPlayers(AppDbContext context)
    {
        if (!context.Players.Any())
        {
            List<Player> players = new()
            {
                new Player
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA0"),
                    FirstName = "Franco",
                    LastName = "Armani",
                    Nationality = "Argentina",
                    Position = "Goalkeeper",
                    Created = DateTime.Now,
                    Enabled = true
                },
                new Player
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1"),
                    FirstName = "Ignacio",
                    LastName = "Fernandez",
                    Nationality = "Argentina",
                    Position = "Midfielder",
                    Created = DateTime.Now,
                    Enabled = true
                },
                new Player
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2"),
                    FirstName = "Mohamed",
                    LastName = "Salah",
                    Nationality = "Egypt",
                    Position = "Forward",
                    Created = DateTime.Now,
                    Enabled = true
                },
                new Player
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA3"),
                    FirstName = "Ibrahima",
                    LastName = "Konaté",
                    Nationality = "French",
                    Position = "Defending",
                    Created = DateTime.Now,
                    Enabled = true
                },
            };

            context.Players.AddRange(players);
            await context.SaveChangesAsync();
        }
    }
}
