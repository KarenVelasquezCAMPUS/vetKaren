using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class ApiVetKarenContext : DbContext
{
    public ApiVetKarenContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Lab> Labs { get; set; }
    public DbSet<MedicalTreatments> MedicalTreatmentss { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<MedicineSupplier> MedicineSuppliers { get; set; }
    public DbSet<MovementDetail> MovementDetails { get; set; }
    public DbSet<MovementMedicine> MovementMedicines { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Quotes> Quotess { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Spice> Spices { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRol> UserRols { get; set; }
    public DbSet<Vet> Vets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
