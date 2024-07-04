using Microsoft.AspNetCore.Mvc;
using SIIMVA_WEB.Services;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Notificacion_iycController : Controller
    {
        private INotificacion_iycService _Notificacion_iycService;
        public Notificacion_iycController(INotificacion_iycService Notificacion_iycService)
        {
            _Notificacion_iycService = Notificacion_iycService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var Notificacion_iyc = _Notificacion_iycService.read();
            if (Notificacion_iyc == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Notificacion_iyc);
        }




    }
}
