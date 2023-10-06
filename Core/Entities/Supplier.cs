namespace Core.Entities;
public class Supplier : BaseEntity
{
    public string Name { get; set; } 
    public string Address { get; set; }
    public int Phone { get; set; }

    public ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
    public ICollection<MedicineSupplier> MedicineSuppliers { get; set; }
}