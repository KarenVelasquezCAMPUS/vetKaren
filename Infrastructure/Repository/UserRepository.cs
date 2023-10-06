using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class UserRepository : GenericRepository<User>, IUser
{
    private readonly ApiVetKarenContext _context;
    public UserRepository(ApiVetKarenContext context) : base(context)
    {
        _context = context;
    }
    public async Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
    }

    // Pag
    public override async Task<(int totalRegistros, IEnumerable<User> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Users as IQueryable<User>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.UserName.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Roles)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

    public override async Task<User> GetByIdAsync(int id)
    {
        return await _context.Set<User>()
        .Include(p => p.Roles)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
