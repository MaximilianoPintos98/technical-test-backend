namespace PintosTechnicalApp.Entities;

public class Stadium : GenericEntity
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public Guid? TeamId { get; set; }
    public virtual Team? Team { get; set; }
}
