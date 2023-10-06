using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100)
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