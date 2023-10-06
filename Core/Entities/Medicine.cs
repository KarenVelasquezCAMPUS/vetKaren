namespace Core.Entities;
public class Medicine : BaseEntity
{
    public int LabId { get; set; }
    public Lab Lab { get; set; }
    public string Name { get; set; }
    public int QuantityAvailable { get; set; }
    public string Price { get; set;}
}