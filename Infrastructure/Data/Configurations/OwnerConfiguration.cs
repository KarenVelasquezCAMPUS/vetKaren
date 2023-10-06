using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("owner");

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
            .HasMaxLength(150)
            .HasColumnName("email");
            
            builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("phone");
        }
    }
}