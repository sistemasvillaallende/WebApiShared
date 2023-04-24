using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BarriosController : Controller
    {
        private IBarriosService _BarriosService;
        public BarriosController(IBarriosService BarriosService)
        {
            _BarriosService = BarriosService;
        }

        [HttpGet]
        public IActionResult getByPk(
        int COD_BARRIO)
        {
            var Barrios = _BarriosService.getByPk(COD_BARRIO);
            if (Barrios == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Barrios);
        }
        [HttpGet]
        public IActionResult read()
        {
            var Barrios = _BarriosService.read();
            if (Barrios == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Barrios);
        }

    }
}

