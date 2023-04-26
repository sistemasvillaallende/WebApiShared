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
        private IResoluciones_multasService _Resoluciones_multasService;

        public ComunicacionesCIDIController(IComunicacionesService ComunicacionesService, INotificacion_digitalService Notificacion_digitalService, 
            IResoluciones_multasService resoluciones_multasService)
        {
            _ComunicacionesService = ComunicacionesService;
            _Notificacion_digitalService = Notificacion_digitalService;
            _Resoluciones_multasService = resoluciones_multasService;
           
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult enviarNotificacionMultas(string cuit,int id_tipo_notif,int id_oficina,int id_usuario,int tipo_reporte,int nro_expediente)
        {
            string cuerpo = "";
            Resoluciones_multas obj = new Resoluciones_multas();
            obj = _Resoluciones_multasService.GetResolucion(nro_expediente);
            if (tipo_reporte==1) /* nro*/
            {
                cuerpo =
                   @"<html>
                    <head>
                        <title>Notificacion de Multas </title>
                    </head>
                    <body>
                        <p>Se notifica. del contenido de la presente y se procede a citarlo 
                           y emplazarlo para que en el término de cinco (5) dias, formule 
                           descargo por escrito y ofrezca las pruebas.
                        </p>
                        <p>En caso de descargo, mencionar número de causa.</p>
                        <p>El horario de atención es de lunes a viernes de 7 a 13Hs, 
                           Oficina ubicada en Goycoechea 686
                        </p>
                          ";
                    cuerpo = cuerpo +" <p> <a href='https://vecino.villaallende.gov.ar/PagosOnLine/Multas.aspx?dominio=NEX918&nroEpediente="+obj.NRO_EXPEDIENTE+"'>Link para pago</a> </p></body> </html>";
            }
            if (tipo_reporte == 2)
            {
                
    
                     cuerpo =
                    @"<html>
                    <head>
                        <title>Notificacion  de Resolucion </title>
                    </head>"+

                   @" <body>
                       <p> Estimado/a "+obj.nombre_noti+ @" </p>
                       <p> Nos dirigimos a usted en relacion a la Resolucion de la multa emitida con causa n" + obj.nro_causa+ @" para la cual se dictamino:</p> "+

                       @" <p>" + obj.ART_1+ @"</p>
                       
                       
                    </body>
                 </html>";




            }
            // <p>CONSIDERANDO: " + obj.CONSIDERANDO + @"</p>
            //< p > ARTICULO 1: " + obj.ART_1 + @" </ p >
            //            < p > ARTICULO 2: " + obj.ART_2 + @" </ p >
            //            < p > ARTICULO 3: " + obj.ART_3 + @" </ p >
            //            < p > ARTICULO 4: " + obj.ART_4 + @" </ p >

            Email email = new Email();
            email.Cuil = cuit;
            email.Asunto = " NOTIFICACION DE MULTAS"  ;
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
                _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, id_tipo_notif, id_oficina, id_usuario, 0);
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, id_tipo_notif,id_oficina,id_usuario,1);
            return Ok(respuesta);
        }
    }
}
