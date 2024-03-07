namespace PintosTechnicalApp.DTOs;

public class BaseDTO
{
    public Guid? Id { get; set; }
    public DateTime? Created {  get; set; }
    public bool? Enabled { get; set; }
}
