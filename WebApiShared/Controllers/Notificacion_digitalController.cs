

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
    public class Notificacion_digitalController : Controller
    {
        private INotificacion_digitalService _Notificacion_digitalService;

        public Notificacion_digitalController(INotificacion_digitalService Notificacion_digitalService)
        {
            _Notificacion_digitalService = Notificacion_digitalService;
        }
        //[HttpGet]
        //public IActionResult getByPk(int idsolic
        //)
        //{
        //    var Notificacion_digital = _Notificacion_digitalService.getByPk();
        //    if (Notificacion_digital == null)
        //    {
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    return Ok(Notificacion_digital);
        //}

        [HttpGet]
        public IActionResult ListarNotificaciones()
        {
            var req = _Notificacion_digitalService.ListarNotificaciones();
            return Ok(req);
        }

        [HttpGet]
        public IActionResult listNotifxTipoNotif(int tipo_notificacion)
        {
            var req = _Notificacion_digitalService.listNotifxTipoNotif(tipo_notificacion);
            return Ok(req);
        }

        [HttpGet]
        public IActionResult listNotifxcuil(string cuil)
        {
            var req = _Notificacion_digitalService.ListNotifxcuil(cuil);
            return Ok(req);
        }

        [HttpGet]
        public IActionResult ListNotifxEstado(int cod_estado)
        {
            var req = _Notificacion_digitalService.ListNotifxEstado(cod_estado);
            return Ok(req);
        }

    }
}

