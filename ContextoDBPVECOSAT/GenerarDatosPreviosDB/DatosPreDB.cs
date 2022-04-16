using ContextoDBPVECOSAT.Model.Catalogo;
using ContextoDBPVECOSAT.Model.Tienda;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDBPVECOSAT.DatosPreviosDB
{
    public class DatosPreDB
    {
        public static void PreLlenado(ModelBuilder builder)
        {
            builder.Entity<RolUsuario>().HasData(TablaRolUsuarios());
            builder.Entity<Usuario>().HasData(TablaUsuarios());
            builder.Entity<Departamento>().HasData(TablaDepartamento());
            builder.Entity <Producto>().HasData(TablaProducto());
        }
        public static List<RolUsuario> TablaRolUsuarios()
        {
            var roles = new List<RolUsuario>();
            roles.Add(new RolUsuario()
            {
                Id = 1,
                Descripcion = "Cajero"
            });
            roles.Add(new RolUsuario()
            {
                Id = 2,
                Descripcion = "Supervisor"
            });

            return roles;

        }
        public static List<Usuario> TablaUsuarios()
        { 
            var usuario = new List<Usuario>();
            usuario.Add(new Usuario()
            {
                Id = 1,
                NombreUsuario = "Damián",
                Password = "pventa1",
                RolUsuarioId = 1,
            });
            usuario.Add(new Usuario()
            {
                Id = 2,
                NombreUsuario = "David",
                Password = "pventa2",
                RolUsuarioId = 2,
            });
            return usuario;
        }

        public static List<Departamento> TablaDepartamento()
        {
            var departamento = new List<Departamento>();
            departamento.Add(new Departamento()
            {
                Id =1,
                Descripcion = "Abarrotes"
            });
            departamento.Add(new Departamento()
            {
                Id = 2,
                Descripcion = "Ropa"
            });
            departamento.Add(new Departamento()
            {
                Id = 3,
                Descripcion = "Dulceria"
            });
            departamento.Add(new Departamento()
            {
                Id = 4,
                Descripcion = "Panaderia"
            });
            return departamento;
        }

        public static List<Producto> TablaProducto()
        {
            var producto = new List<Producto>();
            producto.Add(new Producto()
            {
                Id=1,
                Descripcion = "Azucar",
                Precio = 25.50M,
                DepartamentoId = 1,
            });
            producto.Add(new Producto()
            {
                Id = 2,
                Descripcion = "Lata Atún",
                Precio = 14.00M,
                DepartamentoId= 1,
            });
            producto.Add(new Producto()
            {
                Id = 3,
                Descripcion = "Pantalon Hombre",
                Precio = 299.00M,
                DepartamentoId = 2,
            });
            producto.Add(new Producto()
            {
                Id = 4,
                Descripcion = "Pantalon Mujer",
                Precio = 399.00M,
                DepartamentoId = 2,
            });
            producto.Add(new Producto()
            {
                Id = 5,
                Descripcion = "Chocolate",
                Precio = 20.00M,
                DepartamentoId = 3,
            });
            producto.Add(new Producto()
            {
                Id = 6,
                Descripcion = "Chicle",
                Precio = 5.00M,
                DepartamentoId = 3,
            });
            producto.Add(new Producto()
            {
                Id = 7,
                Descripcion = "Dona Cholate",
                Precio = 7.00M,
                DepartamentoId = 4,
            });
            producto.Add(new Producto()
            {
                Id = 8,
                Descripcion = "Pan Blanco",
                Precio = 5.50M,
                DepartamentoId = 4,
            });
            return producto;
        }

    }
}
