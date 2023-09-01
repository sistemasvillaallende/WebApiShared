
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
    public class Estados_procuracionController : Controller
    {
        private IEstados_procuracionService _Estados_procuracionService;
        public Estados_procuracionController(IEstados_procuracionService Estados_procuracionService)
        {
            _Estados_procuracionService = Estados_procuracionService;
        }
        [HttpGet]
        public IActionResult getByPk(int codigo_estado)
        {
            var Estados_procuracion = _Estados_procuracionService.getByPk(codigo_estado);
            if (Estados_procuracion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Estados_procuracion);
        }
        [HttpGet]
        public IActionResult ListarEstadosxNotif(int nro_emision,int subsistema)
        {
            var req = _Estados_procuracionService.ListarEstadosxNotif(nro_emision,subsistema);
            return Ok(req);
        }

        [HttpGet]
        public IActionResult ListarEstadosxNotifNuevas(int nro_emision, int subsistema)
        {
            var req = _Estados_procuracionService.ListarEstadosxNotifNuevas(nro_emision, subsistema);
            return Ok(req);
        }





    }
}

