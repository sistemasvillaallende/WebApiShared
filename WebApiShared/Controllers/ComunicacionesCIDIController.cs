using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services.CIDI;
using WebApiShared.Services.NOTIFICACIONES;
using WebApiShared.Entities.CIDI.Comunicacion;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComunicacionesCIDIController : Controller
    {
        private IComunicacionesService _ComunicacionesService;
        private INotificacion_digitalService _Notificacion_digitalService;

        public ComunicacionesCIDIController(IComunicacionesService ComunicacionesService, INotificacion_digitalService Notificacion_digitalService)
        {
            _ComunicacionesService = ComunicacionesService;
            _Notificacion_digitalService = Notificacion_digitalService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult enviarNotificacion(string cuit, string subject, string body,int id_tipo_notif,int id_oficina,int id_usuario)
        {
            string cuerpo =
                @"<html>
                    <head>
                        <title>Notificacion </title>
                    </head>
                    <body>
                        <p>Se notifica a Ud. del contenido de la presente y se procede a citarlo 
                           y emplazarlo para que en el término de cinco (5) dias, formule 
                           descargo por escrito y ofrezca las pruebas.
                        </p>
                        <p>En caso de descargo, mencionar número de causa.</p>
                        <p>El horario de atención es de lunes a viernes de 7 a 13Hs, 
                           Oficina ubicada en Goycoechea 686
                        </p>
                    </body>
                 </html>";
            Email email = new Email();
            email.Cuil = cuit;
            email.Asunto = subject;
            //email.Subtitulo = "Subtitulo";
            email.Mensaje = cuerpo;
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

            if (respuesta.Resultado != "OK")
            {
                _Notificacion_digitalService.insertNotif(cuit, subject, body, id_tipo_notif, id_oficina, id_usuario, 0);
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            _Notificacion_digitalService.insertNotif(cuit, subject, body, id_tipo_notif,id_oficina,id_usuario,1);
            return Ok(respuesta);
        }
    }
}
