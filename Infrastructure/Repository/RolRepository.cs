using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly ApiVetKarenContext _context;
    public RolRepository(ApiVetKarenContext context) : base(context)
    {
        _context=context;
    }
     public override async Task<(int totalRegistros, IEnumerable<Rol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Roles as IQueryable<Rol>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Users)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

     public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Set<Rol>()
        .Include(p => p.Users)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
