namespace Core.Entities;
public class Pet : BaseEntity
{
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int SpiceId { get; set; }
    public Spice Spice { get; set; }
    public int RaceId { get; set; }
    public Race Race { get; set; }
    public string Name { get; set; }
    public DateTime BornDate { get; set; }

    public ICollection<Quotes> Quotess { get; set; }
}