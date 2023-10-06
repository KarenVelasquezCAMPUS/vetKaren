using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType>
    {
        public void Configure(EntityTypeBuilder<MovementType> builder)
        {
            builder.ToTable("movementtype");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("description");
        }
    }
}