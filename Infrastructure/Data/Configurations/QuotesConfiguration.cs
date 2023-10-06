using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{ 
    public class QuotesConfiguration : IEntityTypeConfiguration<Quotes>
    {
        public void Configure(EntityTypeBuilder<Quotes> builder)
        {
            builder.ToTable("quotes");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Date)
            .IsRequired()
            .HasColumnType("DateTime")
            .HasColumnName("date");

            builder.Property(p => p.Hour)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("hour");

            builder.Property(p => p.Reason)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("reason");

            //Relations
            builder.HasOne(o => o.Pet)
            .WithMany(m => m.Quotess)
            .HasForeignKey(o => o.PetId);

            builder.HasOne(o => o.Vet)
            .WithMany(m => m.Quotess)
            .HasForeignKey(o => o.VetId);
        }
    }
}