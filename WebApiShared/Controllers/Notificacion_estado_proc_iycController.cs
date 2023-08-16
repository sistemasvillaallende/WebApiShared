using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

using WebApiShared.Services.CIDI;
using WebApiShared.Services.NOTIFICACIONES;
using WebApiShared.Entities.CIDI.Comunicacion;
using WebApiShared.Entities.NOTIFICACIONES;

namespace WebApiShared.Controllers
{

[ApiController]
    [Route("[controller]/[action]")]
    public class Notificacion_estado_proc_iycController : Controller
    {
        private INotificacion_estado_proc_iycService _Notificacion_estado_proc_iycService;
        public Notificacion_estado_proc_iycController(INotificacion_estado_proc_iycService Notificacion_estado_proc_iycService)
        {
            _Notificacion_estado_proc_iycService = Notificacion_estado_proc_iycService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int Nro_Emision)
        {
            var Notificacion_estado_proc_iyc = _Notificacion_estado_proc_iycService.getByPk(Nro_Emision);
            if (Notificacion_estado_proc_iyc == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Notificacion_estado_proc_iyc);
        }
        [HttpGet]
        public IActionResult listNotifProcIyc()
        {
            var Notificacion_estado_proc_iyc = _Notificacion_estado_proc_iycService.ListarNotifProcIyc();
            return Ok(Notificacion_estado_proc_iyc);
        }







    }
}

