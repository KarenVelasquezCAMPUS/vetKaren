using ApiVetKaren.Dtos;
using ApiVetKaren.Helpers;
using ApiVetKaren.Services;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiVetKaren.Controllers;
public class UserController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    public UserController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userService = userService;
    }

    // Registrar user
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RegisterAsync([FromBody] RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    // Token en la cookie
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTokenAsync([FromBody] LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken);
        return Ok(result);
    }

    // Añadir rol
    [HttpPost("addrol")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddRolAsync([FromBody] AddRolDto model)
    {
        var result = await _userService.AddRolAsync(model);
        return Ok(result);
    }

    // Refresh Token
    [HttpPost("refreshtoken")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _userService.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);
        return Ok(response);
    }

    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }

    // Traer user
    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserGetAllDto>> Get(int id)
    {
        var User = await _unitOfWork.Users.GetByIdAsync(id);
        if (User == null) {
            return NotFound();
        }
        return _mapper.Map<UserGetAllDto>(User);
    }

    // User Rol
    [HttpGet("UserName/{UserName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserGetAllDto> GetByUserName(string UserName)
    {
        var UserRol =  _unitOfWork.Users.Find(p => p.UserName == UserName).FirstOrDefault();
        if (UserRol == null) {
            return NotFound();
        }
        return _mapper.Map<UserGetAllDto>(UserRol);
    }

    // Paginacion
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<UserGetAllDto>>> GetTodoPagina([FromQuery] Params UserParams)
    {
        var UsersXroles = await _unitOfWork.Users.GetAllAsync(UserParams.PageIndex, UserParams.PageSize, UserParams.Search);
        var lstUserGetAllDto = _mapper.Map<List<UserGetAllDto>>(UsersXroles.registros);
        return new Pager<UserGetAllDto>(lstUserGetAllDto, UsersXroles.totalRegistros, UserParams.PageIndex, UserParams.PageSize, UserParams.Search);
    }

    // Editar rol de user
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserDto UserDto)
    {
        if (UserDto == null) {
            return NotFound();
        }
        var User = _mapper.Map<UserDto>(UserDto);
        User.Id = id;
        var editUserRol = await _userService.EditUserAsync(User);
        return _mapper.Map<UserDto>(editUserRol);
    }

    // Eliminar user
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> DeleteUser(int id)
    {
        var User = await _unitOfWork.Users.GetByIdAsync(id);
        if (User == null) {
            return NotFound();
        }
        _unitOfWork.Users.Remove(User);
        await _unitOfWork.SaveAsync();
        return NoContent();
    } 
}