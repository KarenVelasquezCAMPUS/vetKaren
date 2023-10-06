using Core.Interfaces;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiVetKarenContext context;
    private UserRepository _users;
    private RolRepository _roles;
    private UsuarioRolRepository _usuarioRoles;

    public UnitOfWork(ApiVetKarenContext _context)
    {
        context = _context;
    }

    public IRol Roles {
        get{
            if(_roles == null){
                _roles = new RolRepository(context);
            }
            return _roles;
        }
    }

    public IUser Users { 
        get{
            if(_users == null){
                _users = new UsuarioRepository(context);
            }
            return _users;
        }
    }

    public IUserRol UserRoles { 
        get{
            if(_userRoles == null){
                _userRoles = new UsuarioRolRepository(context);
            }
            return _userRoles;
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return context.SaveChangesAsync();
    }
}