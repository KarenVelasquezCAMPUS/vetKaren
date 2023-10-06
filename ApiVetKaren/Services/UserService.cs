using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ApiVetKaren.Dtos;
using ApiVetKaren.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiVetKaren.Services;
public class UserService : IUserService 
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly JWT _jwt;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<User> passwordHasher)
    {
        _jwt=jwt.Value;
        _passwordHasher=passwordHasher;
        _unitOfWork=unitOfWork;
    }

    // Register
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var user = new User
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName,
        };
        user.Password = _passwordHasher.HashPassword(user, registerDto.Password);
    
        var userExiste = _unitOfWork.Users
            .Find(u => u.UserName.ToLower() == registerDto.UserName.ToLower())
            .FirstOrDefault();
    
        if (userExiste == null)
        {
            var rolPredeterminado = _unitOfWork.Roles
                .Find(u => u.Name == Authorization.rol_predeterminado.ToString())
                .First();
            try
            {
                user.Roles.Add(rolPredeterminado);
                _unitOfWork.Users.Add(user);
                await _unitOfWork.SaveAsync();
    
                return $"El user  {registerDto.UserName} ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"El user con {registerDto.UserName} ya se encuentra registrado.";
        }
    } 

    // Tener User
    public async Task<DatosUserDto> GetTokenAsync(LoginDto model)
    {
        DatosUserDto datosUserDto = new DatosUserDto();
        var user = await _unitOfWork.Users
            .GetByUserNameAsync(model.UserName);
        if (user == null)
        {
            datosUserDto.EstaAutenticado = false;
            datosUserDto.Mensaje = $"No existe ningún user con el nombre de usuario {model.UserName}.";
            return datosUserDto;
        }
    
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
        if (result == PasswordVerificationResult.Success)
        {
            datosUserDto.Mensaje = "Ok";
            datosUserDto.EstaAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
            datosUserDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            datosUserDto.UserName = user.UserName;
            datosUserDto.Email = user.UserName;
            datosUserDto.Roles = user.Roles
                .Select(p => p.Name)
                .ToList();
    
            if (user.RefreshTokens.Any(p => p.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.Where(p => p.IsActive == true).FirstOrDefault();
                datosUserDto.RefreshToken = activeRefreshToken.Token;
                datosUserDto.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = CreateRefreshToken();
                datosUserDto.RefreshToken = refreshToken.Token;
                datosUserDto.RefreshTokenExpiration = refreshToken.Expires;
                user.RefreshTokens.Add(refreshToken);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveAsync();
            }
            return datosUserDto;
        }
        datosUserDto.EstaAutenticado = false;
        datosUserDto.Mensaje = $"Credenciales incorrectas para el usuario {user.UserName}.";
        return datosUserDto;
    }

    // Añadir Rol
    public async Task<string> AddRolAsync(AddRolDto model)
    {
        var user = await _unitOfWork.Users
            .GetByUserNameAsync(model.UserName);
        if (user == null)
        {
            return $"No existe algún usuario registrado con la cuenta {model.UserName}.";
        }
        var resultado = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
        if (resultado == PasswordVerificationResult.Success)
        {
            var rolExiste = _unitOfWork.Roles
                .Find(u => u.Name.ToLower() == model.Role.ToLower())
                .FirstOrDefault();
            if (rolExiste != null)
            {
                var userTieneRol = user.Roles
                    .Any(u => u.Id == rolExiste.Id);
    
                if (userTieneRol == false)
                {
                    user.Roles.Add(rolExiste);
                    _unitOfWork.Users.Update(user);
                    await _unitOfWork.SaveAsync();
                }
                return $"Rol {model.Role} agregado a la cuenta {model.UserName} de forma exitosa.";
            }
            return $"Rol {model.Role} no encontrado.";
        }
        return $"Credenciales incorrectas para el user {user.UserName}.";
    }

    public async Task<User> EditUserAsync(User model)
    {
        User user = new User();
        user.Id = model.Id;
        user.UserName = model.UserName;
        user.Email = model.Email;
        user.Password = _passwordHasher.HashPassword(user, model.Password);
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveAsync();
        return user;
    }

    public async Task<DatosUserDto> RefreshTokenAsync(string refreshToken)
    {
        var datosUserDto = new DatosUserDto();
    
        var user = await _unitOfWork.Users.GetByRefreshTokenAsync(refreshToken);
    
        if (user == null)
        {
            datosUserDto.EstaAutenticado = false;
            datosUserDto.Mensaje = $"El token no esta asignado a ningun user.";
            return datosUserDto;
        }
    
        var refreshTokenBd = user.RefreshTokens.Single(p => p.Token == refreshToken);
    
        if (!refreshTokenBd.IsActive)
        {
            datosUserDto.EstaAutenticado = false;
            datosUserDto.Mensaje = $"El token no es valido";
            return datosUserDto;
        }
    
        refreshTokenBd.Revoked = DateTime.UtcNow;
    
        var newRefreshToken = CreateRefreshToken();
        user.RefreshTokens.Add(newRefreshToken);
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveAsync();
    
        datosUserDto.Mensaje = "Ok";
        datosUserDto.EstaAutenticado = true;
        JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
        datosUserDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        datosUserDto.UserName = user.UserName;
        datosUserDto.Email = user.UserName;
        datosUserDto.Roles = user.Roles
            .Select(p => p.Name)
            .ToList();
    
        datosUserDto.RefreshToken = newRefreshToken.Token;
        datosUserDto.RefreshTokenExpiration = newRefreshToken.Expires;
        return datosUserDto;
    }

    // Refresh Token
    public RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddDays(10),
                Created = DateTime.UtcNow
            };
        }
    }

    // jwt create
    private JwtSecurityToken CreateJwtToken(User user)
    {
        var roles = user.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Name));
        }
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id.ToString())
        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials
        );
        return jwtSecurityToken;
    

    /*  
    public Task<string> RegisterAsync(RegisterDto model)
    {
        throw new NotImplementedException();
    }

    public Task<DatosUserDto> GetTokenAsync(LoginDto model)
    {
        throw new NotImplementedException();
    }

    public Task<string> AddRolAsync(AddRolDto model)
    {
        throw new NotImplementedException();
    }

    public Task<User> EditUserAsync(User model)
    {
        throw new NotImplementedException();
    }

    Task<DatosUserDto> IUserService.RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }  
    */

    }

    public Task<User> EditUserAsync(UserDto user)
    {
        throw new NotImplementedException();
    }
}