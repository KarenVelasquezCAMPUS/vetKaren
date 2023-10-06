using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVetKaren.Helpers;
public class Authorization
{
    public enum Roles
    {
        Administrador,
        Gerente,
        Empleado,
        Persona
    }
    public const Roles rol_predeterminado = Roles.Persona;
}