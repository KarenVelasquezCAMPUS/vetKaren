using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVetKaren.Dtos;
public class UserGetAllDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<RolDto> Roles { get; set; }

    //public List<UserRolDto> UserRoles { get; set; }
}