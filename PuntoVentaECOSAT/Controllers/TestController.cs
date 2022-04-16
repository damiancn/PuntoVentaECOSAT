using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PuntoVentaECOSAT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
                
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Saludos");
        }
    }
}
