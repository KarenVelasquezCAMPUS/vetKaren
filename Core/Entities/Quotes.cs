namespace Core.Entities;
public class Quotes : BaseEntity
{
    public int PetId { get; set; }
    public Pet Pet { get; set; }
    public int VetId { get; set; }
    public Vet Vet { get; set; }
    public DateTime Date { get; set; }
    public string Hour { get; set; }
    public string Reason { get; set; }

    public ICollection<MedicalTreatments> MedicalTreatmentss { get; set; }
}
