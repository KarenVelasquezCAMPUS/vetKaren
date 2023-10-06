using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class SpiceRepository : ISpice
{
    private readonly ApiVetKarenContext _context;

    public SpiceRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Spice entity)
    {
        _context.Set<Spice>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Spice> entities)
    {
        _context.Set<Spice>().AddRange(entities);
    }

    public virtual IEnumerable<Spice> Find(Expression<Func<Spice, bool>> expression)
    {
        return _context.Set<Spice>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<Spice> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Spices as IQueryable<Spice>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Spice> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Spice entity)
    {
        _context.Set<Spice>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Spice> entities)
    {
        _context.Set<Spice>().RemoveRange(entities);
    }

    public virtual void Update(Spice entity)
    {
        _context.Set<Spice>()
            .Update(entity);
    }
}