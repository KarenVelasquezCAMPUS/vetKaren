using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class UsuarioRolRepository : IUserRol
{
    private readonly ApiVetKarenContext _context;

    public UsuarioRolRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(UserRol entity)
        {
            _context.Set<UserRol>().Add(entity);
        }
    
        public virtual void AddRange(IEnumerable<UserRol> entities)
        {
            _context.Set<UserRol>().AddRange(entities);
        }
    
        public virtual IEnumerable<UserRol> Find(Expression<Func<UserRol, bool>> expression)
        {
            return _context.Set<UserRol>().Where(expression);
        }
    
        // Pag
         public virtual async Task<(int totalRegistros, IEnumerable<UserRol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.UserRoles as IQueryable<UserRol>;
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
    
        public virtual async Task<UserRol> GetByIdAsync(int idUsuario, int idRol)
        {
            return await _context.Set<UserRol>()
                                .FirstOrDefaultAsync(p => p.RolId == idRol &&  p.UserId == idUsuario);
        }
    
        public virtual Task<UserRol> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    
        public virtual void Remove(UserRol entity)
        {
            _context.Set<UserRol>().Remove(entity);
        }
    
        public virtual void RemoveRange(IEnumerable<UserRol> entities)
        {
            _context.Set<UserRol>().RemoveRange(entities);
        }
    
        public virtual void Update(UserRol entity)
        {
            _context.Set<UserRol>()
                .Update(entity);
        }
}