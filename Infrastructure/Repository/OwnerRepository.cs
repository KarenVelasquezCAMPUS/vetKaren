using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class OwnerRepository : IOwner
{
    private readonly ApiVetKarenContext _context;

    public OwnerRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Owner entity)
    {
        _context.Set<Owner>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Owner> entities)
    {
        _context.Set<Owner>().AddRange(entities);
    }

    public virtual IEnumerable<Owner> Find(Expression<Func<Owner, bool>> expression)
    {
        return _context.Set<Owner>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<Owner> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Owners as IQueryable<Owner>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Owner> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Owner entity)
    {
        _context.Set<Owner>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Owner> entities)
    {
        _context.Set<Owner>().RemoveRange(entities);
    }

    public virtual void Update(Owner entity)
    {
        _context.Set<Owner>()
            .Update(entity);
    }
}