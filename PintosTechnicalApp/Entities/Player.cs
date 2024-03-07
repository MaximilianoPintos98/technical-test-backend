namespace PintosTechnicalApp.Entities;

public class Player : Person
{
    public string? Position { get; set; }
    public Guid? TeamId { get; set; }
    public virtual Team? Team { get; set; }
}
