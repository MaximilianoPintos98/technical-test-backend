using PintosTechnicalApp.Entities;

namespace PintosTechnicalApp.Config.Seeds;

public class TrainerSeed
{
    public static async Task AddTrainers(AppDbContext context)
    {
        if (!context.Trainers.Any())
        {
            List<Trainer> trainers = new()
            {
                new Trainer
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA0"),
                    FirstName = "Martin",
                    LastName = "Demichelis",
                    Nationality = "Argentina",
                    Created = DateTime.Now,
                    Enabled = true
                },
                new Trainer
                {
                    Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1"),
                    FirstName = "Jürgen",
                    LastName = "Klopp",
                    Nationality = "Germany",
                    Created = DateTime.Now,
                    Enabled = true
                },
            };

            context.Trainers.AddRange(trainers);
            await context.SaveChangesAsync();
        }
    }
}
