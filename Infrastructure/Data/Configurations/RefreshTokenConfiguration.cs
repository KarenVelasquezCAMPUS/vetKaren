using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder){

            builder.ToTable("refreshtoken");

            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id)
                .IsRequired()
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("idrt");

            builder.Property(p => p.Token)
                .IsRequired()
                .HasColumnName("token")
                .HasMaxLength(500);

            builder.Property(p => p.RefreshTokenK)
                .IsRequired()
                .HasColumnName("refreshtoken")
                .HasMaxLength(200);

            builder.Property(p => p.CreationDate)
                .IsRequired()
                .HasColumnName("creationdate")
                .HasColumnType("DateTime");

            builder.Property(p => p.ExpirationDate)
                .IsRequired()
                .HasColumnName("expirationdate")
                .HasColumnType("DateTime");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasColumnName("isactive");

            // Relations
            builder.HasOne(o => o.User)
                .WithMany(m => m.RefreshTokens)
                .HasForeignKey(d => d.UserId);
        }
    }
