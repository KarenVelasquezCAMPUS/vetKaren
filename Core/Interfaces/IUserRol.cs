using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;
public interface IUserRol
{
    Task<UserRol> GetByIdAsync(int idUser, int idRol);

    //Task<IEnumerable<UserRol>> GetAllAsync();

    IEnumerable<UserRol> Find(Expression<Func<UserRol, bool>> expression);
    Task<(int totalRegistros, IEnumerable<UserRol> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(UserRol entity);
    void AddRange(IEnumerable<UserRol> entities);
    void Remove(UserRol entity);
    void RemoveRange(IEnumerable<UserRol> entities);
    void Update(UserRol entity);
    void Add(global::ApiVetKaren.Dtos.UserRolDto userRol);
    void Update(global::ApiVetKaren.Dtos.UserRolDto userRol);
    void Update(global::ApiVetKaren.Dtos.UserRolDto userRol);
}
