namespace Core.Entities;
public class MovementMedicine : BaseEntity
{
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public int MovementTypeId { get; set; }
    public MovementType MovementType { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public string Entrance { get; set; } // crear tabla only id ?  o nueva relacion

    public ICollection<MovementDetail> MovementDetails { get; set; }
}