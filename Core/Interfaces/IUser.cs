using Core.Entities;

namespace Core.Interfaces;
public interface IUser : IGeneric<User>
{
    Task<User> GetByUsernameAsync(string userName);
    Task<User> GetByRefreshTokenAsync(string userName);
}
