using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MovementMedicineRepository : IMovementMedicine
{
    private readonly ApiVetKarenContext _context;

    public MovementMedicineRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(MovementMedicine entity)
    {
        _context.Set<MovementMedicine>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<MovementMedicine> entities)
    {
        _context.Set<MovementMedicine>().AddRange(entities);
    }

    public virtual IEnumerable<MovementMedicine> Find(Expression<Func<MovementMedicine, bool>> expression)
    {
        return _context.Set<MovementMedicine>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<MovementMedicine> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.MovementMedicines as IQueryable<MovementMedicine>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<MovementMedicine> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(MovementMedicine entity)
    {
        _context.Set<MovementMedicine>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<MovementMedicine> entities)
    {
        _context.Set<MovementMedicine>().RemoveRange(entities);
    }

    public virtual void Update(MovementMedicine entity)
    {
        _context.Set<MovementMedicine>()
            .Update(entity);
    }
}