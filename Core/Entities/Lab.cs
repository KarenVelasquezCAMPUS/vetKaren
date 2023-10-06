namespace Core.Entities;
public class Lab : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Phone { get; set; }

    public ICollection<Medicine> Medicines { get; set; }
}