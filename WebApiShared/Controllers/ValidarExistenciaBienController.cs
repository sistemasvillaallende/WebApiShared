using Microsoft.AspNetCore.Mvc;
using WebApiShared.Services;
using WebApiShared.Entities;
namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValidarExistenciaBienController : Controller
    {
        private IWs_valida_comercioService _ComercioService;
        private IWs_valida_InmuebleService _InmuebleService;
        public ValidarExistenciaBienController(IWs_valida_InmuebleService inmuebleService, 
            IWs_valida_comercioService comercioService)
        {
            _ComercioService = comercioService;
            _InmuebleService = inmuebleService;
        }
        [HttpGet]
        public IActionResult validarInmueble(int circunscripcion, int seccion, int manzana,
            int parcela, int p_h)
        {
            ws_valida_inmueble inmueble = _InmuebleService.getByPk(circunscripcion, seccion, manzana, parcela, p_h);
            if (inmueble == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(inmueble);
        }
        [HttpGet]
        public IActionResult validarComercio(int legajo)
        {
            ws_valida_comercio comercio = _ComercioService.getByPk(legajo);
            if (comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(comercio);
        }
    }
}
