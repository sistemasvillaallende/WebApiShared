
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services.CIDI;
using WebApiShared.Services.NOTIFICACIONES;


namespace WebApiShared.Controllers
{
    //ESTE CONTROLLER MUESTRA EL DETALLE DE LAS PROCURACIONES MASIVAS
    [ApiController]
    [Route("[controller]/[action]")]
    public class Det_notificacion_estado_proc_autoController : Controller
    {
        private IDet_notificacion_estado_proc_autoService _Det_notificacion_estado_proc_autoService;
        public Det_notificacion_estado_proc_autoController(IDet_notificacion_estado_proc_autoService Det_notificacion_estado_proc_autoService)
        {
            _Det_notificacion_estado_proc_autoService = Det_notificacion_estado_proc_autoService;
        }


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



