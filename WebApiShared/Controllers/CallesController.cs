using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CallesController : Controller
    {
        private ICallesService _CallesService;
        public CallesController(ICallesService CallesService)
        {
            _CallesService = CallesService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int COD_CALLE)
        {
            var Calles = _CallesService.getByPk(COD_CALLE);
            if (Calles == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Calles);
        }
        [HttpGet]
        public IActionResult Read()
        {
            var Calles = _CallesService.read();
            if (Calles == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Calles);
        }
    }
}

