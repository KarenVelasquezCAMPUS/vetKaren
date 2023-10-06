using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiVetKarenContext context;

    private LabRepository _labs;
    private MedicalTreatmentsRepository _medicalTreatments;
    private MedicineRepository _medicines;
    private MedicineSupplierRepository _medicineSuppliers;
    private MovementDetailRepository _movementDetails;
    private MovementMedicineRepository _movementMedicines;
    private MovementTypeRepository _movementTypes;
    private OwnerRepository _owners;
    private PetRepository _pets;
    private QuotesRepository _quotess;
    private RaceRepository _races;
    private RefreshTokenRepository _refreshTokens;
    private SpiceRepository _spices;
    private SupplierRepository _suppliers;
    private UserRepository _users;
    private RolRepository _roles;
    private UserRolRepository _userRoles;
    private VetRepository _vets;

    public UnitOfWork(ApiVetKarenContext _context)
    {
        context = _context;
    }

    public ILab Labs 
    {
        get
        {
            if(_labs == null)
            {
                _labs = new LabRepository(context);
            }
            return _labs;
        }
    }

    public IMedicalTreatments MedicalTreatments 
    {
        get
        {
            if(_medicalTreatments == null)
            {
                _medicalTreatments = new MedicalTreatmentsRepository(context);
            }
            return _medicalTreatments;
        }
    }

    public IMedicine Medicine 
    {
        get
        {
            if(_medicines == null)
            {
                _medicines = new MedicineRepository(context);
            }
            return _medicines;
        }
    }

    public IMedicineSupplier MedicineSupplier 
    {
        get
        {
            if(_medicineSuppliers == null)
            {
                _medicineSuppliers = new MedicineSupplierRepository(context);
            }
            return _medicineSuppliers;
        }
    }

    public IMovementDetail MovementDetail 
    {
        get
        {
            if(_movementDetails == null)
            {
                _movementDetails = new MovementDetailRepository(context);
            }
            return _movementDetails;
        }
    }

    public IMovementMedicine MovementMedicine 
    {
        get
        {
            if(_movementMedicines == null)
            {
                _movementMedicines = new MovementMedicineRepository(context);
            }
            return _movementMedicines;
        }
    }

    public IMovementType MovementType 
    {
        get
        {
            if(_movementTypes == null)
            {
                _movementTypes = new MovementTypeRepository(context);
            }
            return _movementTypes;
        }
    }

    public IOwner Owner 
    {
        get
        {
            if(_owners == null)
            {
                _owners = new OwnerRepository(context);
            }
            return _owners;
        }
    }

    public IPet Pet 
    {
        get
        {
            if(_pets == null)
            {
                _pets = new PetRepository(context);
            }
            return _pets;
        }
    }

    public IQuotes Quotes 
    {
        get
        {
            if(_quotess == null)
            {
                _quotess = new QuotesRepository(context);
            }
            return _quotess;
        }
    }

    public IRace Race 
    {
        get
        {
            if(_races == null)
            {
                _races = new RaceRepository(context);
            }
            return _races;
        }
    }

    public IRefreshToken RefreshToken 
    {
        get
        {
            if(_refreshTokens == null)
            {
                _refreshTokens = new RefreshTokenRepository(context);
            }
            return _refreshTokens;
        }
    }

    public IRol Rol 
    {
        get
        {
            if(_roles == null)
            {
                _roles = new RolRepository(context);
            }
            return _roles;
        }
    }

    public ISpice Spice 
    {
        get
        {
            if(_spices == null)
            {
                _spices = new SpiceRepository(context);
            }
            return _spices;
        }
    }

    public ISupplier Supplier 
    {
        get
        {
            if(_suppliers == null)
            {
                _suppliers = new SupplierRepository(context);
            }
            return _suppliers;
        }
    }

    public IUser Users 
    { 
        get
        {
            if(_users == null)
            {
                _users = new UserRepository(context);
            }
            return _users;
        }
    }

    public IUserRol UserRoles 
    { 
        get
        {
            if(_userRoles == null)
            {
                _userRoles = new UserRolRepository(context);
            }
            return _userRoles;
        }
    }

    public IVet Vet 
    {
        get
        {
            if(_vets == null)
            {
                _vets = new VetRepository(context);
            }
            return _vets;
        }
    }

    // Implementacion Quick fix
    public IMedicalTreatments MedicalTreatmentss => throw new NotImplementedException();

    public IMedicine Medicines => throw new NotImplementedException();

    public IMedicineSupplier MedicineSuppliers => throw new NotImplementedException();

    public IMovementDetail MovementDetails => throw new NotImplementedException();

    public IOwner Owners => throw new NotImplementedException();

    public IPet Pets => throw new NotImplementedException();

    public IQuotes Quotess => throw new NotImplementedException();

    public IRace Races => throw new NotImplementedException();

    public IRefreshToken RefreshTokens => throw new NotImplementedException();

    public IRol Roles => throw new NotImplementedException();

    public ISpice Spices => throw new NotImplementedException();

    public ISupplier Suppliers => throw new NotImplementedException();

    public IVet Vets => throw new NotImplementedException();


    public void Dispose()
    {
        context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return context.SaveChangesAsync();
    }
}