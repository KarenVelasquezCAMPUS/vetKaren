namespace Core.Entities;
public class Spice : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Pet> Pets { get; set; }
    public ICollection<Race> Races { get; set; }
}