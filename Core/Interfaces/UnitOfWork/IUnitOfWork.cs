namespace Core.Interfaces;
public interface IUnitOfWork
{
    ILab Labs { get; }
    IMedicalTreatments MedicalTreatmentss { get; }
    IMedicine Medicines { get; }
    IMedicineSupplier MedicineSuppliers { get; }
    IMovementDetail MovementDetails { get; }
    IMovementMedicine MovementMedicine { get; }
    IMovementType MovementType { get; }
    IOwner Owners { get; }
    IPet Pets { get; }
    IQuotes Quotess { get; }
    IRace Races { get; }
    IRefreshToken RefreshTokens { get; }
    IRol Roles { get; }
    ISpice Spices { get; }
    ISupplier Suppliers { get; }
    IUser Users { get; }
    IUserRol UserRoles { get; }
    IVet Vets { get; }

    Task<int> SaveAsync();
}