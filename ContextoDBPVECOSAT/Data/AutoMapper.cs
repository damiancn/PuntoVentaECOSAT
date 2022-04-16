using AutoMapper;
using ContextoDBPVECOSAT.Model.Catalogo;
using ContextoDBPVECOSAT.ModelVM.CatalogoVM;
using ContextoDBPVECOSAT.Model.Tienda;
using ContextoDBPVECOSAT.ModelVM.TiendaVM;
using ContextoDBPVECOSAT.Model.Venta;
using ContextoDBPVECOSAT.ModelVM.VentaVM;

namespace ContextoDBPVECOSAT.Data
{
    public class AutoMapperClass:Profile
    {
        public AutoMapperClass()
        {
            #region Catalogo

            #region RolUsuario
            CreateMap<RolUsuario, RolUsuarioVM>();
            CreateMap<RolUsuarioVM, RolUsuario>();
            #endregion

            #region Usuario
            CreateMap<Usuario, UsuarioVM>()
                .ForMember(e => e.RolUsuarioDescripcion, mo => mo.MapFrom(e => e.RolUsuario.Descripcion));
            CreateMap<UsuarioVM, Usuario>();
            #endregion

            #endregion

            #region Tienda

            #region Departamento
            CreateMap<Departamento, DepartamentoVM>();
            CreateMap<DepartamentoVM, Departamento>();
            #endregion

            #region Producto
            CreateMap<Producto, ProductoVM>()
                .ForMember(e => e.DepartamentoDescripcion, mo => mo.MapFrom(e => e.Departamento.Descripcion));
            CreateMap<ProductoVM, Producto>();
            #endregion
            #endregion

            #region Venta

            #region Venta
            CreateMap<Venta, VentaVM>()
                .ForMember(e => e.UsuarioDescripcion, mo => mo.MapFrom(e => e.Usuario.NombreUsuario));
            CreateMap<VentaVM, Venta>();
            #endregion

            #region SubVenta
            CreateMap<SubVenta, SubVentaVM>()
                .ForMember(e => e.ProductoDescripcion, mo => mo.MapFrom(e => e.Producto.Descripcion));
            CreateMap<SubVentaVM, SubVenta>();
            #endregion
            #endregion
        }
    }
}
