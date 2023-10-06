using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MedicalTreatmentsConfiguration : IEntityTypeConfiguration<MedicalTreatments>
    {
        public void Configure(EntityTypeBuilder<MedicalTreatments> builder)
        {
            builder.ToTable("medicaltreatments");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Dose)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("dose");

            builder.Property(p => p.AdminDate)
            .IsRequired()
            .HasColumnType("DateTime")
            .HasColumnName("date");

            builder.Property(p => p.Observation)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("observation");

            // Relations
            builder.HasOne(o => o.Quotes)
            .WithMany(m => m.MedicalTreatmentss)
            .HasForeignKey(o => o.QuotesId);

            builder.HasOne(o => o.Medicine)
            .WithMany(m => m.MedicalTreatmentss)
            .HasForeignKey(o => o.MedicineId);
        }
    }
}