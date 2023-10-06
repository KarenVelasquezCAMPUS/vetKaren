namespace Core.Entities;
public class Race : BaseEntity
{
    public int SpiceId { get; set; }
    public Spice Spice { get; set; }
    public string Name { get; set; }

    public ICollection<Pet> Pets { get; set; }
    public ICollection<Spice> Spices { get; set; }
}