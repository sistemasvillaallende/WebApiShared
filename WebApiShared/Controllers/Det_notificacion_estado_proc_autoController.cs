
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
    public class Det_notificacion_estado_proc_autoController : Controller
    {
        private IDet_notificacion_estado_proc_autoService _Det_notificacion_estado_proc_autoService;
        public Det_notificacion_estado_proc_autoController(IDet_notificacion_estado_proc_autoService Det_notificacion_estado_proc_autoService)
        {
            _Det_notificacion_estado_proc_autoService = Det_notificacion_estado_proc_autoService;
        }
        // [HttpGet]
        //public IActionResult getByPk(
        //int Nro_Emision, int Nro_Notificacion)
        //{
        //    var Det_notificacion_estado_proc_auto = _Det_notificacion_estado_proc_autoService.getByPk(Nro_Emision, Nro_Notificacion);
        //    if (Det_notificacion_estado_proc_auto == null)
        //    {
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    return Ok(Det_notificacion_estado_proc_auto);
        //}

        [HttpGet]
        public IActionResult listarDetalle(int nro_emision)
        {
            var Det_notificacion_estado_proc_auto = _Det_notificacion_estado_proc_autoService.ListarDetalle(nro_emision);
            return Ok(Det_notificacion_estado_proc_auto);
        }

        [HttpGet]
        public IActionResult listarDetallexEstado(int nro_emision, int cod_estado)
        {
            var Det_notificacion_estado_proc_auto = _Det_notificacion_estado_proc_autoService.ListarDetallexEstado(nro_emision, cod_estado);
            return Ok(Det_notificacion_estado_proc_auto);
        }



    }
}



