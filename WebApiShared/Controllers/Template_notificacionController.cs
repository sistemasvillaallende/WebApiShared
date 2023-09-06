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
    public class Template_notificacionController : Controller
    {
        private ITemplate_notificacionService _Template_notificacionService;
        public Template_notificacionController(ITemplate_notificacionService Template_notificacionService)
        {
            _Template_notificacionService = Template_notificacionService;
        }
        [HttpGet]
        public IActionResult ObtenerTextoReporte(int idTemplate)
        {
            var req = _Template_notificacionService.ObtenerTextoReporte(idTemplate);
            return Ok(req);
        }

    }
}
