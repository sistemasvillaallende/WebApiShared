
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
    public class Det_notificacion_estado_proc_inmController : Controller
    {
        private IDet_notificacion_estado_proc_inmService _Det_notificacion_estado_proc_inmService;
        public Det_notificacion_estado_proc_inmController(IDet_notificacion_estado_proc_inmService Det_notificacion_estado_proc_inmService)
        {
            _Det_notificacion_estado_proc_inmService = Det_notificacion_estado_proc_inmService;
        }
        //[HttpGet]
        //public IActionResult getByPk(
        //int Nro_emision, int Nro_notificacion)
        //{
        //    var Det_notificacion_estado_proc_inm = _Det_notificacion_estado_proc_inmService.getByPk(Nro_emision, Nro_notificacion);
        //    if (Det_notificacion_estado_proc_inm == null)
        //    {
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    return Ok(Det_notificacion_estado_proc_inm);
        //}

        [HttpGet]
        public IActionResult listarDetalle(int nro_emision)
        {
            var Det_notificacion_estado_proc_inm = _Det_notificacion_estado_proc_inmService.ListarDetalle(nro_emision);
            return Ok(Det_notificacion_estado_proc_inm);
        }

        [HttpGet]
        public IActionResult listarDetallexEstado(int nro_emision, int cod_estado)
        {
            var Det_notificacion_estado_proc_inm = _Det_notificacion_estado_proc_inmService.ListarDetallexEstado(nro_emision, cod_estado);
            return Ok(Det_notificacion_estado_proc_inm);
        }






    }
}

