
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
    public class Det_notificacion_estado_proc_iycController : Controller
    {
        private IDet_notificacion_estado_proc_iycService _Det_notificacion_estado_proc_iycService;
        public Det_notificacion_estado_proc_iycController(IDet_notificacion_estado_proc_iycService Det_notificacion_estado_proc_iycService)
        {
            _Det_notificacion_estado_proc_iycService = Det_notificacion_estado_proc_iycService;
        }
        //[HttpGet]
        //public IActionResult getByPk(
        //int Nro_Emision, int Nro_Notificacion)
        //{
        //    var Det_notificacion_estado_proc_iyc = _Det_notificacion_estado_proc_iycService.getByPk(Nro_Emision, Nro_Notificacion);
        //    if (Det_notificacion_estado_proc_iyc == null)
        //    {
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    return Ok(Det_notificacion_estado_proc_iyc);
        //}


        [HttpGet]
        public IActionResult listarDetalle(int nro_emision)
        {
            var Det_notificacion_estado_proc_iyc = _Det_notificacion_estado_proc_iycService.ListarDetalle(nro_emision);
            return Ok(Det_notificacion_estado_proc_iyc);
        }

        [HttpGet]
        public IActionResult listarDetallexEstado(int nro_emision, int cod_estado)
        {
            var Det_notificacion_estado_proc_iyc = _Det_notificacion_estado_proc_iycService.ListarDetallexEstado(nro_emision, cod_estado);
            return Ok(Det_notificacion_estado_proc_iyc);
        }





    }
}


