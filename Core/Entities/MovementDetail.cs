namespace Core.Entities;
public class MovementDetail : BaseEntity
{
    public string Exit { get; set; } // crear tabla only id ?
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public int MovementMedicineId { get; set; }
    public MovementMedicine MovementMedicine { get; set; }
    public int Amount { get; set; }
    public string Price { get; set; }
}