using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MovementTypeRepository : IMovementType
{
    private readonly ApiVetKarenContext _context;

    public MovementTypeRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(MovementType entity)
    {
        _context.Set<MovementType>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<MovementType> entities)
    {
        _context.Set<MovementType>().AddRange(entities);
    }

    public virtual IEnumerable<MovementType> Find(Expression<Func<MovementType, bool>> expression)
    {
        return _context.Set<MovementType>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<MovementType> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.MovementTypes as IQueryable<MovementType>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<MovementType> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(MovementType entity)
    {
        _context.Set<MovementType>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<MovementType> entities)
    {
        _context.Set<MovementType>().RemoveRange(entities);
    }

    public virtual void Update(MovementType entity)
    {
        _context.Set<MovementType>()
            .Update(entity);
    }
}