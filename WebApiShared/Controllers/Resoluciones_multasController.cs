using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services.NOTIFICACIONES;

namespace webApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Resoluciones_multasController : Controller
    {
        private IResoluciones_multasService _Resoluciones_multasService;
        public Resoluciones_multasController(IResoluciones_multasService Resoluciones_multasService)
        {
            _Resoluciones_multasService = Resoluciones_multasService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int COD_OFICINA, int NRO_EXPEDIENTE, string NRO_RESOLUCION)
        {
            var Resoluciones_multas = _Resoluciones_multasService.getByPk(COD_OFICINA, NRO_EXPEDIENTE, NRO_RESOLUCION);
            if (Resoluciones_multas == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Resoluciones_multas);
        }
        [HttpGet]
        public IActionResult GetDatosExpedienteNotificar( int nro_expediente, int tipo_reporte)
        {
            var Resoluciones_multas = _Resoluciones_multasService.GetDatosExpedienteNotificar(nro_expediente, tipo_reporte);
            if (Resoluciones_multas == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Resoluciones_multas);
        }
        







    }
}

