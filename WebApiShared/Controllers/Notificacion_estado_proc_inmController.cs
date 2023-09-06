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
    public class Notificacion_estado_proc_inmController : Controller
    {
        private INotificacion_estado_proc_inmService _Notificacion_estado_proc_inmService;
        public Notificacion_estado_proc_inmController(INotificacion_estado_proc_inmService Notificacion_estado_proc_inmService)
        {
            _Notificacion_estado_proc_inmService = Notificacion_estado_proc_inmService;
        }

        [HttpGet]
        public IActionResult listNotifProcInm()
        {
            var Notificacion_estado_proc_inm = _Notificacion_estado_proc_inmService.ListarNotifProcInm();
            return Ok(Notificacion_estado_proc_inm);
        }
        //[HttpGet]
        //public IActionResult getByPk(
        //int Nro_emision, DateTime Fecha_emision)
        //{
        //    var Notificacion_estado_proc_inm = _Notificacion_estado_proc_inmService.getByPk(Nro_emision, Fecha_emision);
        //    if (Notificacion_estado_proc_inm == null)
        //    {
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    return Ok(Notificacion_estado_proc_inm);
        //}







    }
}

