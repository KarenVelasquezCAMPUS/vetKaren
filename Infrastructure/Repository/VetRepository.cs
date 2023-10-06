using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class VetRepository : IVet
{
    private readonly ApiVetKarenContext _context;

    public VetRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Vet entity)
    {
        _context.Set<Vet>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Vet> entities)
    {
        _context.Set<Vet>().AddRange(entities);
    }

    public virtual IEnumerable<Vet> Find(Expression<Func<Vet, bool>> expression)
    {
        return _context.Set<Vet>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<Vet> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Vets as IQueryable<Vet>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Vet> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Vet entity)
    {
        _context.Set<Vet>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Vet> entities)
    {
        _context.Set<Vet>().RemoveRange(entities);
    }

    public virtual void Update(Vet entity)
    {
        _context.Set<Vet>()
            .Update(entity);
    }
}