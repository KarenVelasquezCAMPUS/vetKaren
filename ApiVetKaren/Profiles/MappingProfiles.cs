using ApiVetKaren.Dtos;
using AutoMapper;
using Core.Entities;

namespace ApiVetKaren.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rol, RolDto>()
        .ReverseMap();

        CreateMap<Rol, RolPostDto>()
        .ReverseMap();

        CreateMap<Rol, RolGetAllDto>()
        .ReverseMap();

        CreateMap<User, UserDto>()
        .ReverseMap();

        CreateMap<User, UserGetAllDto>()
        .ReverseMap();

        CreateMap<UserRol, UserRolDto>()
        .ReverseMap();
    }
}