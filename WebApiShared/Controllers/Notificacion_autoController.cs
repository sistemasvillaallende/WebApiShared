    using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using SIIMVA_WEB.Services;

namespace SIIMVA_WEB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Notificacion_autoController : Controller
    {
        private INotificacion_autoService _Notificacion_autoService;
        public Notificacion_autoController(INotificacion_autoService Notificacion_autoService)
        {
            _Notificacion_autoService = Notificacion_autoService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var Notificacion_auto = _Notificacion_autoService.read();
            if (Notificacion_auto == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Notificacion_auto);
        }
    }
}

