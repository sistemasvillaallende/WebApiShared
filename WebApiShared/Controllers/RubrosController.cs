using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RubrosController : Controller
    {
        private IRubrosService _RubrosService;
        public RubrosController(IRubrosService RubrosService)
        {
            _RubrosService = RubrosService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int cod_rubro, int anio)
        {
            var Rubros = _RubrosService.getByPk(cod_rubro, anio);
            if (Rubros == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Rubros);
        }
        [HttpGet]
        public IActionResult readBajoRiesgo()
        {
            var Rubros = _RubrosService.readBajoRiesgo();
            if (Rubros == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Rubros);
        }
        [HttpGet]
        public IActionResult read()
        {
            var Rubros = _RubrosService.read();
            if (Rubros == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Rubros);
        }
        [HttpGet]
        public IActionResult getByComercio(int leg)
        {
            var Rubros = _RubrosService.getByComercio(leg);
            if (Rubros == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Rubros);
        }




    }
}

