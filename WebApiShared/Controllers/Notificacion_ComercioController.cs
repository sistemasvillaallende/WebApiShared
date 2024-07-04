using Microsoft.AspNetCore.Mvc;
using SIIMVA_WEB.Services;
using WebApiShared.Services.NOTIFICACIONES;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Notificacion_ComercioController : Controller
    {
        private INotificacion_comercioServices _Notificacion_comercioService;
        public Notificacion_ComercioController(INotificacion_comercioServices Notificacion_comercioService)
        {
            _Notificacion_comercioService = Notificacion_comercioService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var Notificacion_comercio = _Notificacion_comercioService.read();
            if (Notificacion_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Notificacion_comercio);
        }
    }
}
