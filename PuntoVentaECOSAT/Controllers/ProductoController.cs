using AutoMapper;
using ContextoDBPVECOSAT.Data;
using ContextoDBPVECOSAT.Model.Tienda;
using ContextoDBPVECOSAT.ModelVM;
using ContextoDBPVECOSAT.ModelVM.TiendaVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace PuntoVentaECOSAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IMapper mapper;
        private readonly Contexto ctx;
        public ProductoController(IMapper mapper, Contexto ctx)
        {
            this.mapper = mapper;
            this.ctx = ctx;
        }


        [HttpGet]
        public async Task<RespuestaVM> ObtenerTodos()
        {
            try
            {
                var productos = mapper.Map<List<ProductoVM>>(await this.ctx.Productos.Include(e => e.Departamento).ToListAsync());
                return new RespuestaVM() { Estatus = true, Mensaje = "Lista Objetos", Objeto = productos };
            }
            catch (Exception ex)
            {
                return new RespuestaVM() { Estatus = false, Mensaje = ex.Message, Objeto = null };
            }
            
        }


        [HttpGet("{id}")]
        public async Task<RespuestaVM> ObtenerId(int id)
        {
            try
            {
                var productos = mapper.Map<ProductoVM>(await this.ctx.Productos.Include(e => e.Departamento).Where(e=>e.Id==id).FirstOrDefaultAsync());
                return new RespuestaVM() { Estatus = true, Mensaje = "Lista Objetos", Objeto = productos };
            }
            catch (Exception ex)
            {
                return new RespuestaVM() { Estatus = false, Mensaje = ex.Message, Objeto = null };
            }
            
        }

        [HttpGet, Route("departamento")]
        public async Task<RespuestaVM> ObtenerDepartamento()
        {
            try
            {
                var departamentos = mapper.Map<List<DepartamentoVM>>(await this.ctx.Departamentos.ToListAsync());
                return  new RespuestaVM() { Estatus = true, Mensaje = "Departamento", Objeto = departamentos };
            }
            catch (Exception ex)
            {
            return new RespuestaVM() { Estatus = false, Mensaje = ex.Message, Objeto = null };
            }
        }

        [HttpPost]
        public async Task<RespuestaVM> Guardar(ProductoVM model)
        {
            try
            {
                var producto = await this.ctx.Productos.Where(e => e.Descripcion == model.Descripcion).FirstOrDefaultAsync();
                if (producto == null)
                {
                    var guardar=this.mapper.Map<Producto>(model);
                    this.ctx.Add(guardar);
                    await this.ctx.SaveChangesAsync();
                    return new RespuestaVM() { Estatus = true, Mensaje = "Guardado", Objeto = model };
                }
                return new RespuestaVM() { Estatus = false, Mensaje = "Producto existe", Objeto = null };
            }
            catch (Exception)
            {
                return new RespuestaVM() { Estatus = false, Mensaje = "Error servidor", Objeto = null };
            }

        }
        [HttpPut("{id}")]
        public async Task<RespuestaVM> Editar(int id, ProductoVM model)
        {
            try
            {
                var producto = await this.ctx.Productos.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (producto != null)
                {
                    producto.Descripcion = model.Descripcion;
                    producto.Precio = model.Precio;
                    producto.DepartamentoId = model.DepartamentoId;
                    await this.ctx.SaveChangesAsync();
                    return new RespuestaVM() { Estatus = true, Mensaje = "ProductoActualizado", Objeto = model };
                }
                return new RespuestaVM() { Estatus = false, Mensaje = "Producto no existe", Objeto = null };
            }
            catch (Exception)
            {
                return new RespuestaVM() { Estatus = false, Mensaje = "Error servidor", Objeto = null };
            }

        }
    }
}
