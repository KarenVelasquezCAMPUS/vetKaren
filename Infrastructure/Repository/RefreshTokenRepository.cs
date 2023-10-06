using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class RefreshTokenRepository : IRefreshToken
{
    private readonly ApiVetKarenContext _context;

    public RefreshTokenRepository(ApiVetKarenContext context)
    {
        _context = context;
    }

     public virtual void Add(RefreshToken entity)
    {
        _context.Set<RefreshToken>().Add(entity);
    }
    
    public virtual void AddRange(IEnumerable<RefreshToken> entities)
    {
        _context.Set<RefreshToken>().AddRange(entities);
    }

    public virtual IEnumerable<RefreshToken> Find(Expression<Func<RefreshToken, bool>> expression)
    {
        return _context.Set<RefreshToken>().Where(expression);
    }

    // Pag
    public virtual async Task<(int totalRegistros, IEnumerable<RefreshToken> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.RefreshTokens as IQueryable<RefreshToken>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual Task<RefreshToken> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(RefreshToken entity)
    {
        _context.Set<RefreshToken>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<RefreshToken> entities)
    {
        _context.Set<RefreshToken>().RemoveRange(entities);
    }

    public virtual void Update(RefreshToken entity)
    {
        _context.Set<RefreshToken>()
            .Update(entity);
    }
}