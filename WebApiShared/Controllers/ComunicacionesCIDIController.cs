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
            obj = _Resoluciones_multasService.GetDatosExpedienteNotificar(nro_expediente,1);
            if (tipo_reporte==1) /* nro*/
            {
                cuerpo =
                   @"<html>
                    <head>
                        <title>Notificación para: "+obj.nombre_noti+@" Cuit: "+cuit+@" Nro. de Notificación xxx</title>
                    </head>
                    <body>
                        <br>
                        <p>INFRACCIONES DE TRANSITO ** MUNICIPALIDAD DE VILLA ALLENDE</p>

                          <p>Dominio: "+obj.dominio+@" </p>
                          <br>
                            <p>Causa:"+obj.nro_causa+@"/"+obj.ANIO+@"  ** Acta Nro: "+obj.nro_acta+@" </p>
                            <p> Fecha de Infracción:"+obj.FECHA_ACTA_INFRACCION+@" Hs.</p>
                            <p>  Falta Cometida: "+obj.motivos+@" </p>

                        <p>Se notifica a Ud. del contenido de la presente y se procede a citarlo y emplazarlo
                           para que en el término de cinco (5) días, formule descargo en los términos de ley 
                         y ofrezca las pruebas.
                        </p>
                        <p>Si acepta la infracción y desea abonarla con los descuentos previstos a tal fin, 
                          puede hacerlo desde el  siguiente vínculo ";
                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/Multas.aspx?dominio=NEX918&nroEpediente=" + obj.NRO_EXPEDIENTE + "'>Link para pago</a> </p>";
                cuerpo = cuerpo + @" <p>El horario de atención es de lunes a viernes de 7 a 13Hs.
                         Oficina ubicada en Goycoechea 686</p>
                        <p> Tel: 03543-439280 int. 321/322</p>
                         </body> </html> ";
                    
            }
            if (tipo_reporte == 2)
            {
                Resoluciones_multas obj2 = new Resoluciones_multas();
                obj2 = _Resoluciones_multasService.GetResolucion(nro_expediente);

                cuerpo =
               @"<html>
                    <head>
                        <title>Notificacion  de Resolucion </title>
                    </head>" +

              @" <body>
                       <p> Estimado/a " + obj2.nombre_noti + @" </p>
                       <p> Nos dirigimos a usted en relacion a la Resolucion de la multa emitida con causa nro: " + obj2.nro_causa + @"/" + obj2.ANIO + @" para la cual se dictamino:</p> " +

                  @" <p>" + obj2.ART_1 + @"</p>";
                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/Multas.aspx?dominio=NEX918&nroEpediente=" + obj2.NRO_EXPEDIENTE + @"'>Link para pago</a>
                    </body>
                 </html>";




            }
   

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
                _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, id_tipo_notif, id_oficina, id_usuario, 0, nro_expediente);
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, id_tipo_notif,id_oficina,id_usuario,1, nro_expediente);
            _Notificacion_digitalService.updateSumario(nro_expediente,tipo_reporte);
            _Notificacion_digitalService.InsertarNuevoEstado(nro_expediente,id_usuario ,tipo_reporte);
            return Ok(respuesta);
        }
    }
}
