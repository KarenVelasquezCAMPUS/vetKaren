namespace Core.Entities;
public class Medicine : BaseEntity
{
    public int LabId { get; set; }
    public Lab Lab { get; set; }
    public string Name { get; set; }
    public int QuantityAvailable { get; set; }
    public string Price { get; set;}

    public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    public ICollection<MedicineSupplier> MedicineSuppliers { get; set; }
    public ICollection<MedicalTreatments> MedicalTreatmentss { get; set; }
    public ICollection<MovementMedicine> MovementMedicines { get; set; }
    public ICollection<MovementDetail> MovementDetails { get; set; }
}