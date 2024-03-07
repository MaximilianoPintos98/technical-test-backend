using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Config.Seeds;

public class StadiumSeed
{
    public static async Task AddStadiums(AppDbContext context)
    {
        if (!context.Stadiums.Any())
        {
            List<Stadium> stadiums = new()
            {
                new Stadium
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA0"),
                    Name = "Más Monumental",
                    City = "Nuñez",
                    //TeamId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA0"),
                    Created = DateTime.Now,
                    Enabled = true
                },
                new Stadium
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1"),
                    Name = "Anfield",
                    City = "Liverpool",
                    //TeamId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1"),
                    Created = DateTime.Now,
                    Enabled = true
                },
            };

            context.Stadiums.AddRange(stadiums);
            await context.SaveChangesAsync();
        }
    }
}
