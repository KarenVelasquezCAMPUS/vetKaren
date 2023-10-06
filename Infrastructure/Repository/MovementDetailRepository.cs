using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MovementDetailRepository : IMovementDetail
{
    private readonly ApiVetKarenContext _context;

    public MovementDetailRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(MovementDetail entity)
    {
        _context.Set<MovementDetail>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<MovementDetail> entities)
    {
        _context.Set<MovementDetail>().AddRange(entities);
    }

    public virtual IEnumerable<MovementDetail> Find(Expression<Func<MovementDetail, bool>> expression)
    {
        return _context.Set<MovementDetail>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<MovementDetail> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.MovementDetails as IQueryable<MovementDetail>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<MovementDetail> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(MovementDetail entity)
    {
        _context.Set<MovementDetail>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<MovementDetail> entities)
    {
        _context.Set<MovementDetail>().RemoveRange(entities);
    }

    public virtual void Update(MovementDetail entity)
    {
        _context.Set<MovementDetail>()
            .Update(entity);
    }
}