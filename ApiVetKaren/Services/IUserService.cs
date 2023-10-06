using ApiVetKaren.Dtos;
using Core.Entities;

namespace ApiVetKaren.Services;
public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);

    //Task<string> RegisterAsync(RegisterDto registerDto, int opcionPersona, int personaId);

    Task<DatosUserDto> GetTokenAsync(LoginDto model);
    Task<string> AddRolAsync(AddRolDto model);
    Task<User> EditUserAsync(User model);
    Task<DatosUserDto> RefreshTokenAsync(string refreshToken);
    Task<User> EditUserAsync(UserDto user);
}