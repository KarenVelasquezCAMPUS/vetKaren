using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces;
public interface IUser : IGenericRespository<User>
{
    Task<User> GetByUserNameAsync(string userName);
    Task<User> GetByRefreshTokenAsync(string userName);
}
