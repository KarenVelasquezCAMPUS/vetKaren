using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MedicineRepository : IMedicine
{
    private readonly ApiVetKarenContext _context;

    public MedicineRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(Medicine entity)
    {
        _context.Set<Medicine>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<Medicine> entities)
    {
        _context.Set<Medicine>().AddRange(entities);
    }

    public virtual IEnumerable<Medicine> Find(Expression<Func<Medicine, bool>> expression)
    {
        return _context.Set<Medicine>().Where(expression);
    }

    // Pag
        public virtual async Task<(int totalRegistros, IEnumerable<Medicine> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Medicines as IQueryable<Medicine>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<Medicine> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Medicine entity)
    {
        _context.Set<Medicine>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<Medicine> entities)
    {
        _context.Set<Medicine>().RemoveRange(entities);
    }

    public virtual void Update(Medicine entity)
    {
        _context.Set<Medicine>()
            .Update(entity);
    }
}