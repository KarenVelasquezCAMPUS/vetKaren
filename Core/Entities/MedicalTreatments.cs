namespace Core.Entities;
public class MedicalTreatments
{
    public int QuotesId { get; set; } //HasPk
    public Quotes Quotes { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public string Dose { get; set; }
    public DateTime AdminDate { get; set; }
    public string Observation { get; set; }
}