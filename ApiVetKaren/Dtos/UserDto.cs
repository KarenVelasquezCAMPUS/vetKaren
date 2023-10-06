using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVetKaren.Dtos;
public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    //public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    //public ICollection<userRol> UserRoles { get; set; }        
}