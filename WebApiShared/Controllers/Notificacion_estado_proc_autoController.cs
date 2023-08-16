
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services.CIDI;
using WebApiShared.Services.NOTIFICACIONES;

namespace WebApiShared.Controllers
{

        [ApiController]
        [Route("[controller]/[action]")]
        public class Notificacion_estado_proc_autoController : Controller
        {
            private INotificacion_estado_proc_autoService _Notificacion_estado_proc_autoService;
            public Notificacion_estado_proc_autoController(INotificacion_estado_proc_autoService Notificacion_estado_proc_autoService)
            {
                _Notificacion_estado_proc_autoService = Notificacion_estado_proc_autoService;
            }
            [HttpGet]
            public IActionResult getByPk(
            int Nro_Emision)
            {
                var Notificacion_estado_proc_auto = _Notificacion_estado_proc_autoService.getByPk(Nro_Emision);
                if (Notificacion_estado_proc_auto == null)
                {
                    return BadRequest(new { message = "Error al obtener los datos" });
                }
                return Ok(Notificacion_estado_proc_auto);
            }
            [HttpGet]
            public IActionResult listNotifProcAuto()
            {
                var Notificacion_estado_proc_auto = _Notificacion_estado_proc_autoService.ListarNotifProcAuto();
                return Ok(Notificacion_estado_proc_auto);
            }






        }
    
}

