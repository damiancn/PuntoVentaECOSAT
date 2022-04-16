using ContextoDBPVECOSAT.Model.Catalogo;
using ContextoDBPVECOSAT.Model.Venta;
using ContextoDBPVECOSAT.Model.Tienda;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDBPVECOSAT.DatosPreviosDB;

namespace ContextoDBPVECOSAT.Data
{
    public class Contexto:DbContext
    {

        public Contexto(DbContextOptions option):base(option)
        {

        }
        #region Catalogo
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        #endregion

        #region Venta
        public DbSet<Venta>Ventas { get; set; }
        public DbSet<SubVenta> SubVentas { get; set;}
        #endregion

        #region Tienda
        public DbSet<Departamento> Departamentos { get; set;}
        public DbSet<Producto> Productos { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            DatosPreDB.PreLlenado(builder);
        }
    }
}