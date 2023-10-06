namespace Core.Entities;
public class MovementMedicine : BaseEntity
{
    public string Entrance { get; set; } // crear tabla only id ? 
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
}