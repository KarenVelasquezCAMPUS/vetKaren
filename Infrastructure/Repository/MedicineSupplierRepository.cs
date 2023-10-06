using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MedicineSupplierRepository : IMedicineSupplier
{
    private readonly ApiVetKarenContext _context;

    public MedicineSupplierRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(MedicineSupplier entity)
    {
        _context.Set<MedicineSupplier>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<MedicineSupplier> entities)
    {
        _context.Set<MedicineSupplier>().AddRange(entities);
    }

    public virtual IEnumerable<MedicineSupplier> Find(Expression<Func<MedicineSupplier, bool>> expression)
    {
        return _context.Set<MedicineSupplier>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<MedicineSupplier> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.MedicineSuppliers as IQueryable<MedicineSupplier>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<MedicineSupplier> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(MedicineSupplier entity)
    {
        _context.Set<MedicineSupplier>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<MedicineSupplier> entities)
    {
        _context.Set<MedicineSupplier>().RemoveRange(entities);
    }

    public virtual void Update(MedicineSupplier entity)
    {
        _context.Set<MedicineSupplier>()
            .Update(entity);
    }
}