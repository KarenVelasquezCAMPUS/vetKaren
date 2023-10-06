using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class SupplierRepository : ISupplier
{
    private readonly ApiVetKarenContext _context;

    public SupplierRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Supplier entity)
    {
        _context.Set<Supplier>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Supplier> entities)
    {
        _context.Set<Supplier>().AddRange(entities);
    }

    public virtual IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> expression)
    {
        return _context.Set<Supplier>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<Supplier> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Suppliers as IQueryable<Supplier>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Supplier> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Supplier entity)
    {
        _context.Set<Supplier>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Supplier> entities)
    {
        _context.Set<Supplier>().RemoveRange(entities);
    }

    public virtual void Update(Supplier entity)
    {
        _context.Set<Supplier>()
            .Update(entity);
    }
}