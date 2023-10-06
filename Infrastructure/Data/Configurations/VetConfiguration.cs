using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class VetConfiguration : IEntityTypeConfiguration<Vet>
    {
        public void Configure(EntityTypeBuilder<Vet> builder)
        {
            builder.ToTable("vet");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

            builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("email");
            
            builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("phone");

            builder.Property(p => p.Speciality)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("speciality");
        }
    }
}