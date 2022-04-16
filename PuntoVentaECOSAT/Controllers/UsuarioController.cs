using AutoMapper;
using ContextoDBPVECOSAT.Data;
using ContextoDBPVECOSAT.ModelVM;
using ContextoDBPVECOSAT.ModelVM.CatalogoVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PuntoVentaECOSAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IMapper mapper;
        private readonly Contexto ctx;

        public UsuarioController(IMapper mapper, Contexto ctx)
        {
            this.mapper = mapper;
            this.ctx = ctx;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Saludos");
        }
        [HttpPost]
        public async Task<RespuestaVM> InicioSesion(UsuarioVM model)
        {
            try
            {
                var sesion = mapper.Map<UsuarioVM>(await this.ctx.Usuarios.Where(e => e.NombreUsuario == model.NombreUsuario && e.Password == model.Password).FirstOrDefaultAsync());
                if (sesion!=null)
                {
                    return new RespuestaVM() { Estatus = true, Mensaje = "Inicio Sesion", Objeto = sesion };
                }
                else
                {
                    return new RespuestaVM() { Estatus = true, Mensaje = "No existe", Objeto = null };
                }
            }
            catch (Exception ex)
            {
                return new RespuestaVM() { Estatus= false, Mensaje = "Error", Objeto = null};
            }
        }
    }
}
