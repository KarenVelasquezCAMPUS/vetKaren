using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class LabRepository : ILab
{
    private readonly ApiVetKarenContext _context;

    public LabRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Lab entity)
        {
            _context.Set<Lab>().Add(entity);
        }
    
        public virtual void AddRange(IEnumerable<Lab> entities)
        {
            _context.Set<Lab>().AddRange(entities);
        }
    
        public virtual IEnumerable<Lab> Find(Expression<Func<Lab, bool>> expression)
        {
            return _context.Set<Lab>().Where(expression);
        }
    
        // Pag
         public virtual async Task<(int totalRegistros, IEnumerable<Lab> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Labs as IQueryable<Lab>;
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
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