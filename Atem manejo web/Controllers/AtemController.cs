using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Atem_manejo_web.Controllers
{
    public class AtemController : Controller
    {
        private readonly AtemService _atemService;
        public AtemController(AtemService atemService)
        {
            _atemService = atemService;
        }
        [HttpGet("connect")]
        public IActionResult ConnectAtem(string ipAddress)
        {
            var conexion =_atemService.Connect(ipAddress);
            if (conexion.Equals("Error"))
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, conexion);
            }
            else
            {
                return Ok(conexion);
            }
        }
    }
}
