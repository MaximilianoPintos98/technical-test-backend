namespace PintosTechnicalApp.Entities;

public class Team : GenericEntity
{
    public Team()
    {
        Players = new List<Player>();
    }

    public string? Name { get; set; }
    public string? City { get; set; }
    public Guid? TrainerId { get; set; }
    public Guid? StadiumId { get; set; }
    public virtual List<Player>? Players { get; set; }
    public virtual Trainer? Trainer { get; set; }
    public virtual Stadium? Stadium { get; set; }
}
