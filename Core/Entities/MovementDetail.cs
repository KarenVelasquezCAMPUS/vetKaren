namespace Core.Entities;
public class MovementDetail : BaseEntity
{
    public string Exit { get; set; } 
    public string Product { get; set; }
    public int MovementMedicineId { get; set; }
    public MovementMedicine MovementMedicine { get; set; }
    public int Amount { get; set; }
    public string Price { get; set; }
}