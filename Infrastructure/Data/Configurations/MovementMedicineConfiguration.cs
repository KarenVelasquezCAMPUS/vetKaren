using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MovementMedicineConfiguration : IEntityTypeConfiguration<MovementMedicine>
    {
        public void Configure(EntityTypeBuilder<MovementMedicine> builder)
        {
            builder.ToTable("movementmedicine");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnName("amount");

            builder.Property(p => p.Date)
            .IsRequired()
            .HasColumnType("DateTime")
            .HasColumnName("date");

            //Relations
            builder.HasOne(o => o.Medicine)
            .WithMany(m => m.MovementMedicines)
            .HasForeignKey(o => o.MedicineId);

            builder.HasOne(o => o.MovementType)
            .WithMany(m => m.MedicineMovements)
            .HasForeignKey(o => o.MovementTypeId);
        }
    }
}