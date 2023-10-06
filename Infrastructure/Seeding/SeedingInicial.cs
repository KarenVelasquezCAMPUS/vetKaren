using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeding;
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var AdministradorRol = new Rol()
            {
                Id = 1,
                Name = "Administrador"
            };
            var GerenteRol = new Rol()
            {
                Id = 2,
                Name = "Gerente"
            };
            var EmpleadoRol = new Rol()
            {
                Id = 3,
                Name = "Empleado"
            };
            var PersonaRol = new Rol()
            {
                Id = 4,
                Name = "Persona"
            };
            var Administrador = new User()
            {
                Id=1,
                UserName="Admin",
                Email="admin@gmail.com",
            };
            var _passwordHasher = new PasswordHasher<User>();
            Administrador.Password = _passwordHasher.HashPassword(Administrador, "123456");
            var AdminUsuarioRol = new UserRol()
            {
                RolId = 1,
                UserId = 1
            };
            modelBuilder.Entity<User>().HasData(Administrador);
            modelBuilder.Entity<Rol>().HasData(AdministradorRol, EmpleadoRol, PersonaRol, GerenteRol);
            modelBuilder.Entity<UserRol>().HasData(AdminUsuarioRol);
        }
    }