namespace PintosTechnicalApp.Entities;

public class Trainer : Person
{
    public Guid? TeamId { get; set; }
    public virtual Team? Team { get; set; }
}
