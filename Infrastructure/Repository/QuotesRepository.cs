using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class QuotesRepository : IQuotes
{
    private readonly ApiVetKarenContext _context;

    public QuotesRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Quotes entity)
    {
        _context.Set<Quotes>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Quotes> entities)
    {
        _context.Set<Quotes>().AddRange(entities);
    }

    public virtual IEnumerable<Quotes> Find(Expression<Func<Quotes, bool>> expression)
    {
        return _context.Set<Quotes>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<Quotes> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Quotess as IQueryable<Quotes>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Quotes> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Quotes entity)
    {
        _context.Set<Quotes>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Quotes> entities)
    {
        _context.Set<Quotes>().RemoveRange(entities);
    }

    public virtual void Update(Quotes entity)
    {
        _context.Set<Quotes>()
            .Update(entity);
    }
}