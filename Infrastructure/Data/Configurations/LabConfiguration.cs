using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class LabConfiguration : IEntityTypeConfiguration<Lab>
    {
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder.ToTable("lab");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

            builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("address");

            builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("phone");
        }
    }
}