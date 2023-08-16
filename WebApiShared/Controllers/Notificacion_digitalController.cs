

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
        public IActionResult ListNotifxOficina(int cod_oficina)
        {
            var req = _Notificacion_digitalService.ListNotifxOficina(cod_oficina);
            return Ok(req);
        }

        [HttpGet]
        public IActionResult GetOficinas(int cod_usuario)
        {
            var req = _Notificacion_digitalService.GetOficinas(cod_usuario);
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

