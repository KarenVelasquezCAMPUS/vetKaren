using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("medicine");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("name");

            builder.Property(p => p.QuantityAvailable)
            .IsRequired()
            .HasColumnName("quantityavailable");

            builder.Property(p => p.Price)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("price");

            // Relations
            builder.HasOne(o => o.Lab)
            .WithMany(m => m.Medicines)
            .HasForeignKey(o => o.LabId);

            // MedicineSupplier
            builder
            .HasMany(h => h.Suppliers)
            .WithMany(m => m.Medicines)
            .UsingEntity<MedicineSupplier>
            (
                j => j
                .HasOne(o => o.Supplier)
                .WithMany(m => m.MedicineSuppliers)
                .HasForeignKey(o => o.SupplierId),

                j => j
                .HasOne(o => o.Medicine)
                .WithMany(m => m.MedicineSuppliers)
                .HasForeignKey(o => o.MedicineId),

                j =>
                {
                    j.ToTable("medicinesupplier");
                    j.HasKey(k => new
                    {
                        k.MedicineId, 
                        k.SupplierId
                    });
                }
            );
        }
    }
}