using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class RaceRepository : IRace
{
    private readonly ApiVetKarenContext _context;

    public RaceRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Race entity)
    {
        _context.Set<Race>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Race> entities)
    {
        _context.Set<Race>().AddRange(entities);
    }

    public virtual IEnumerable<Race> Find(Expression<Func<Race, bool>> expression)
    {
        return _context.Set<Race>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<Race> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Races as IQueryable<Race>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Race> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Race entity)
    {
        _context.Set<Race>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Race> entities)
    {
        _context.Set<Race>().RemoveRange(entities);
    }

    public virtual void Update(Race entity)
    {
        _context.Set<Race>()
            .Update(entity);
    }
}