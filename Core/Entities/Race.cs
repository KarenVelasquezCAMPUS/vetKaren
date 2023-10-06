namespace Core.Entities;
public class Race : BaseEntity
{
    public int SpiceId { get; set; }
    public Spice Spice { get; set; }
    public string Name { get; set; }
}