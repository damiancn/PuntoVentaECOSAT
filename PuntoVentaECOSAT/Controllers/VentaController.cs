using AutoMapper;
using ContextoDBPVECOSAT.Data;
using ContextoDBPVECOSAT.Model.Venta;
using ContextoDBPVECOSAT.ModelVM;
using ContextoDBPVECOSAT.ModelVM.VentaVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PuntoVentaECOSAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        private readonly IMapper mapper;
        private readonly Contexto ctx;
        public VentaController(IMapper mapper, Contexto ctx)
        {
            this.mapper = mapper;
            this.ctx = ctx;
        }

        [HttpGet]
        public async Task<RespuestaVM> ObtenerTodos()
        {
            try
            {
                var productos = mapper.Map<List<VentaVM>>(await this.ctx.Ventas.Include(e=>e.Usuario).ToListAsync());
                return new RespuestaVM() { Estatus = true, Mensaje = "Ventas Realizadas", Objeto = productos };
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
                var ventas = mapper.Map<List<SubVentaVM>>(await this.ctx.SubVentas.Include(e => e.Venta).Include(e=>e.Producto).Where(e=>e.VentaId==id).ToListAsync());
                return new RespuestaVM() { Estatus = true, Mensaje = "Ventas Realizadas", Objeto = ventas };
            }
            catch (Exception ex)
            {
                return new RespuestaVM() { Estatus = false, Mensaje = ex.Message, Objeto = null };
            }

        }
        [HttpPost("{id}")]
        public async Task<RespuestaVM> Guardar(int id,[FromBody] List<SubVentaVM> model)
        {
            try
            {
                decimal importeTotal = 0.00M;
                var totalPrdto = 0;
                importeTotal = model.Sum(e => e.Importe);
                totalPrdto = model.Sum(e => e.Cantidad);
                Venta nVenta = new Venta()
                {
                    ImporteTotal = importeTotal,
                    CantidadProductos = totalPrdto,
                    Fecha = DateTime.Now,
                    UsuarioId = id,
                };
                this.ctx.Ventas.Add(nVenta);
                this.ctx.SaveChanges();
                var buscarRegistro = this.ctx.Ventas.ToList().Last();

                foreach (var item in model)
                {
                    var subV = new SubVenta()
                    {
                        VentaId = buscarRegistro.Id,
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        Importe = item.Importe,
                    };
                    this.ctx.SubVentas.Add(subV);
                    this.ctx.SaveChanges();
                }
                return new RespuestaVM() { Estatus = true, Mensaje = "Venta Exitosa", Objeto = null };
            }
            catch (Exception)
            {
                return new RespuestaVM() { Estatus = false, Mensaje = "Error servidor", Objeto = null };
            }

        }

    }
}

