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
            .HasMany(p=>p.Roles)
            .WithMany(p=>p.Users)
            .UsingEntity<UserRol>
            (
                j=>j
                .HasOne(p=>p.Rol)
                .WithMany(p=>p.UserRoles)
                .HasForeignKey(p=>p.RolId),

                j=>j
                .HasOne(p=>p.User)
                .WithMany(p=>p.UserRoles)
                .HasForeignKey(p=>p.UserId),

                j=>
                {
                    j.ToTable("UsuarioRol");
                    j.HasKey(p=> new{p.UserId, p.RolId});
                });
                
                builder.HasMany(p=>p.RefreshTokens)
                .WithOne(p=>p.User)
                .HasForeignKey(p=>p.UserId);
        }
    }