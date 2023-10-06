using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion;
    public class UsuarioConfiguracion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(p => p.UserName)
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Password)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100);

            builder
            .HasMany(h => h.Roles)
            .WithMany(m => m.Users)
            .UsingEntity<UserRol>
            (
                j=>j
                .HasOne(o => o.Rol)
                .WithMany(m => m.UserRoles)
                .HasForeignKey(o => o.RolId),

                j=>j
                .HasOne(o => o.User)
                .WithMany(m => m.UserRoles)
                .HasForeignKey(o => o.UserId),

                j=>
                {
                    j.ToTable("userrol");
                    j.HasKey(k => new
                    {
                        k.UserId, 
                        k.RolId
                    });
                });
                
                builder.HasMany(p => p.RefreshTokens)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }