using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services.CIDI;
using WebApiShared.Entities.CIDI.Comunicacion;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComunicacionesCIDIController : Controller
    {
        private IComunicacionesService _ComunicacionesService;
        public ComunicacionesCIDIController(IComunicacionesService ComunicacionesService)
        {
            _ComunicacionesService = ComunicacionesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult enviarNotificacion(string cuit, string subject, string body)
        {
            Email email = new Email();
            email.Cuil = cuit;
            email.Asunto = subject;
            //email.Subtitulo = "Subtitulo";
            email.Mensaje = body;
            //email.InfoDesc = "InfoDesc";
            //email.InfoDato = "InfoDato";
            //email.InfoLink = "http://google.com";
            email.Firma = "Juzgado de Faltas";
            email.Ente = "Municipalidad de Villa Allende";
            email.Id_App = Config.CiDiIdAplicacion;
            email.Pass_App = Config.CiDiPassAplicacion;
            email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
            var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
            if (respuesta == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(respuesta);
        }
    }
}
