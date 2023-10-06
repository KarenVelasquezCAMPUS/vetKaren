namespace Core.Entities;
public class MovementType : BaseEntity
{
    public string Description { get; set; }

    public ICollection<MovementMedicine> MedicineMovements { get; set; }
}