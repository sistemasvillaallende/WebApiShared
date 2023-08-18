using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using SIIMVA_WEB.Services;

namespace SIIMVA_WEB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Det_notificacion_autoController : Controller
    {
        private IDet_notificacion_autoService _Det_notificacion_autoService;
        public Det_notificacion_autoController(IDet_notificacion_autoService Det_notificacion_autoService)
        {
            _Det_notificacion_autoService = Det_notificacion_autoService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var Det_notificacion_auto = _Det_notificacion_autoService.read();
            if (Det_notificacion_auto == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Det_notificacion_auto);
        }







    }
}

