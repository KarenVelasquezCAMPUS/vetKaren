using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class RolConfiguracion : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("rol");

        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Id)
        .IsRequired()
        .HasColumnName("id");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnName("name");

        /* 
        // User Rol
        builder
        .HasMany(h => h.Users)
        .WithMany(m => m.Roles)
        .UsingEntity<UserRol>
        (
            j => j
            .HasOne(o => o.User)
            .WithMany(m => m.UserRols)
            .HasForeignKey(o => o.UserId),

            j => j
            .HasOne(o => o.Rol)
            .WithMany(m => m.UserRols)
            .HasForeignKey(o => o.RoleId),

            j =>
            {
                j.ToTable("userrol");
                j.HasKey(k => new
                {
                    k.RolId, 
                    k.UserId
                });
            }
        ); 
        */
    }
}