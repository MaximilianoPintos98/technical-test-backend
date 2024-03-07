using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Config.Seeds;

public class TeamSeed
{
    public static async Task AddTeams(AppDbContext context)
    {
        if (!context.Teams.Any())
        {
            List<Team> teams = new()
            {
                new Team
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA0"),
                    Name = "River Plate",
                    City = "Nuñez",
                    StadiumId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA0"),
                    Created = DateTime.Now,
                    Enabled = true
                },
                new Team
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1"),
                    Name = "Liverpool",
                    City = "Liverpool",
                    StadiumId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1"),
                    Created = DateTime.Now,
                    Enabled = true
                }
            };

            context.Teams.AddRange(teams);
            await context.SaveChangesAsync();
        }
    }
}
