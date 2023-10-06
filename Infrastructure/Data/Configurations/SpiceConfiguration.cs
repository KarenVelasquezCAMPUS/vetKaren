using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class SpiceConfiguration : IEntityTypeConfiguration<Spice>
    {
        public void Configure(EntityTypeBuilder<Spice> builder)
        {
            builder.ToTable("spice");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");
        }
    }
}