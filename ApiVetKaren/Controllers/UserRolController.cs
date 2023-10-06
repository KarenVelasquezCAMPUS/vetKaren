using ApiVetKaren.Dtos;
using ApiVetKaren.Helpers;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVetKaren.Controllers;

[ApiVersion("1.0")] 
[ApiVersion("1.1")] 

public class UserRolController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserRolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Paginacion
    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<UserRolDto>>> GetPaginaUserRol([FromQuery] Params userParams)
    {
        var usersRoles = await _unitOfWork.UserRoles.GetAllAsync(userParams.PageIndex, userParams.PageSize, userParams.Search);

        var lstUsuRolDto = _mapper.Map<List<UserRolDto>>(usersRoles.registros);

        return new Pager<UserRolDto>(lstUsuRolDto, usersRoles.totalRegistros, userParams.PageIndex, userParams.PageSize, userParams.Search);
    }

    // User Rol
    [HttpGet("{idUser}/{idRol}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserRolDto>> GetByIdUserRol( int iduser, int idRol)
    {
        var UserRol = await _unitOfWork.UserRoles.GetByIdAsync(iduser, idRol);

        if (UserRol == null) {
            return NotFound();
        }

        return _mapper.Map<UserRolDto>(UserRol);
    }

    // Rol ad searc
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserRolDto>> Post(UserRolDto UserRolDto)
    {
        var UserRol = _mapper.Map<UserRolDto>(UserRolDto);
        _unitOfWork.UserRoles.Add(UserRol);
        await _unitOfWork.SaveAsync();

        if (UserRol == null) {
            return BadRequest();
        }

        return _mapper.Map<UserRolDto>(UserRol);
    }

    // Rol ad inser
    [HttpPut("{idUser}/{idRol}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserRolDto>> Put(int iduser, int idRol, [FromBody] UserRolDto UserRolDto)
    {
        if (UserRolDto == null) {
            return NotFound();
        }

        var UserRol = _mapper.Map<UserRolDto>(UserRolDto);
        UserRol.UserId = iduser;
        UserRol.RolId = idRol;
        _unitOfWork.UserRoles.Update(UserRol);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserRolDto>(UserRol);        
    }

    // Rol ad delet
    [HttpDelete("{iduser}/{idRol}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserRolDto>> Delete(int idUser, int idRol)
    {
        var UserRol = await _unitOfWork.UserRoles.GetByIdAsync (idUser, idRol);
        
        if (UserRol == null) {
            return NotFound();
        }

        _unitOfWork.UserRoles.Remove(UserRol);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}