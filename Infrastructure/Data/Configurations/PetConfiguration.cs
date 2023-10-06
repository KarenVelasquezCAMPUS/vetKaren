using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pet");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("name");

            builder.Property(p => p.BornDate)
            .IsRequired()
            .HasColumnType("DateTime")
            .HasColumnName("borndate");

            //Relations
            builder.HasOne(o => o.Owner)
            .WithMany(m => m.Pets)
            .HasForeignKey(o => o.OwnerId);

            builder.HasOne(o => o.Spice)
            .WithMany(m => m.Pets)
            .HasForeignKey(o => o.SpiceId);

            builder.HasOne(x => x.Race)
            .WithMany(x => x.Pets)
            .HasForeignKey(x => x.RaceId);
        }
    }
}