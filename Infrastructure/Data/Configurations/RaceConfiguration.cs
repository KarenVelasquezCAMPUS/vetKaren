using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.ToTable("race");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

            //Relations
            builder.HasOne(o => o.Spice)
            .WithMany(m => m.Races)
            .HasForeignKey(o => o.SpiceId);
        }
    }
}