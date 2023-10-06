namespace Core.Entities;
public class Vet : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Speciality { get; set; }

    public ICollection<Quotes> Quotess { get; set; }
}
