using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVetKaren.Dtos;
public class RolGetAllDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UserDto> Users { get; set; }

    //public List<userRolDto> UserRoles { get; set; }
}