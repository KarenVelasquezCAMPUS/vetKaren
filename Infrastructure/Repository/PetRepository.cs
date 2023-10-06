using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class PetRepository : IPet
{
    private readonly ApiVetKarenContext _context;

    public PetRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Pet entity)
    {
        _context.Set<Pet>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Pet> entities)
    {
        _context.Set<Pet>().AddRange(entities);
    }

    public virtual IEnumerable<Pet> Find(Expression<Func<Pet, bool>> expression)
    {
        return _context.Set<Pet>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<Pet> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Pets as IQueryable<Pet>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Pet> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Pet entity)
    {
        _context.Set<Pet>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Pet> entities)
    {
        _context.Set<Pet>().RemoveRange(entities);
    }

    public virtual void Update(Pet entity)
    {
        _context.Set<Pet>()
            .Update(entity);
    }
}