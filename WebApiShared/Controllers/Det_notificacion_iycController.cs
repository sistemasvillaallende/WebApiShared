using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using SIIMVA_WEB.Services;

namespace SIIMVA_WEB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Det_notificacion_iycController : Controller
    {
        private IDet_notificacion_iycService _Det_notificacion_iycService;
        public Det_notificacion_iycController(IDet_notificacion_iycService Det_notificacion_iycService)
        {
            _Det_notificacion_iycService = Det_notificacion_iycService;
        }

        [HttpGet]
        public IActionResult read(int nro_emision)
        {
            var Det_notificacion_iyc = _Det_notificacion_iycService.read(nro_emision);
            if (Det_notificacion_iyc == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Det_notificacion_iyc);
        }

        [HttpGet]
        public IActionResult listarDetalle(int nro_emision)
        {
            var Det_notificacion_iyc = _Det_notificacion_iycService.listarDetalle(nro_emision);
            if (Det_notificacion_iyc == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Det_notificacion_iyc);
        }

        [HttpGet]
        public IActionResult listarDetallexEstado(int nro_emision, int cod_estado)
        {
            var Det_notificacion_iyc = _Det_notificacion_iycService.listarDetallexEstado(nro_emision, cod_estado);
            if (Det_notificacion_iyc == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Det_notificacion_iyc);
        }


    }
}

