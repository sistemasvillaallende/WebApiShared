using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

using WebApiShared.Services.CIDI;
using WebApiShared.Services.NOTIFICACIONES;
using WebApiShared.Entities.CIDI.Comunicacion;
using WebApiShared.Entities.NOTIFICACIONES;
using Microsoft.Extensions.Hosting.Internal;
using SIIMVA_WEB.Services;
using SIIMVA_WEB;
using System.Reflection.PortableExecutable;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComunicacionesCIDIController : Controller
    {
        private IComunicacionesService _ComunicacionesService;
        private INotificacion_digitalService _Notificacion_digitalService;
        private IResoluciones_multasService _Resoluciones_multasService;
        private IDet_notificacion_estado_proc_autoService _Det_notificacion_estado_proc_autoService;
        private IDet_notificacion_estado_proc_inmService _Det_notificacion_estado_proc_inmService;
        private IDet_notificacion_estado_proc_iycService _Det_notificacion_estado_proc_iycService;
        private IDet_notificacion_autoService _Det_notificacion_autoService;

        public class ModeloDeDatos
        {
            public string cuit { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
        }
        public class ModeloProcuracion
        {
            public string cuit { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
            public int nro_emision { get; set; }
            public int nro_notificacion { get; set; }
            public int nro_procuracion { get; set; }
            public int id_oficina { get; set; }
            public int id_usuario { get; set; }
            public int tipo_proc { get; set; }
            public int idTemplate { get; set; }
            public string tituloReporte { get; set; }
            public int cod_estado_actual { get; set; }

        }
        public class ModeloDelphi
        {
            public string? cuit { get; set; }
            public string? id_oficina { get; set; }
            public string? id_usuario { get; set; }
        }

        public ComunicacionesCIDIController(IComunicacionesService ComunicacionesService, INotificacion_digitalService Notificacion_digitalService,
            IResoluciones_multasService resoluciones_multasService, IDet_notificacion_estado_proc_autoService det_Notificacion_Estado_Proc_AutoService,
            IDet_notificacion_estado_proc_inmService det_Notificacion_Estado_Proc_InmService,
            IDet_notificacion_estado_proc_iycService det_Notificacion_Estado_Proc_IycService,
            IDet_notificacion_autoService det_Notificacion_AutoService)
        {
            _ComunicacionesService = ComunicacionesService;
            _Notificacion_digitalService = Notificacion_digitalService;
            _Resoluciones_multasService = resoluciones_multasService;
            _Det_notificacion_estado_proc_autoService = det_Notificacion_Estado_Proc_AutoService;
            _Det_notificacion_estado_proc_inmService = det_Notificacion_Estado_Proc_InmService;
            _Det_notificacion_estado_proc_iycService = det_Notificacion_Estado_Proc_IycService;
            _Det_notificacion_autoService = det_Notificacion_AutoService;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult enviarNotificacionMultas(string cuit, int id_tipo_notif, int id_oficina, int id_usuario, int tipo_reporte, int nro_expediente)
        {
            string cuerpo = "";
            int nro_notif = 0;
            Resoluciones_multas obj = new Resoluciones_multas();
            obj = _Resoluciones_multasService.GetDatosExpedienteNotificar(nro_expediente, 1);

            Email email = new Email();
            email.Cuil = cuit;
            email.Asunto = " NOTIFICACION DE MULTAS";
            email.Mensaje = " ";
            email.Firma = "Juzgado de Faltas";
            email.Ente = "Municipalidad de Villa Allende";
            email.Id_App = Config.CiDiIdAplicacion;
            email.Pass_App = Config.CiDiPassAplicacion;
            email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
            nro_notif = _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, id_tipo_notif, id_oficina, id_usuario, 0, nro_expediente);
            if (tipo_reporte == 1) /* nro*/
            {

                cuerpo =
                   @"<html>
                      
                    <body>
                  
                        <p> INFRACCIONES DE TRANSITO  MUNICIPALIDAD DE VILLA ALLENDE </p> 
                        <p>Notificación para: " + obj.nombre_noti + @" </p>
                        <p> Nro. de Notificación digital " + nro_notif.ToString() + @"</p>

                          <p>Dominio: " + obj.dominio + @" </p>
                            <p> Causa: " + obj.nro_causa + @"/" + obj.ANIO + @"  </p>  
                            <p>  Acta Nro: " + obj.nro_acta + @"       Fecha de Infracción: " + obj.FECHA_ACTA_INFRACCION + @" Hs.</p>
                            <p>  Falta Cometida: " + obj.motivos + @" </p>

                        <p>Se notifica a Ud. del contenido de la presente y se procede a citarlo y emplazarlo
                           para que en el término de cinco (5) días, formule descargo en los términos de ley 
                         y ofrezca las pruebas.</p>

                        <p>Si acepta la infracción y desea abonarla con los descuentos previstos a tal fin, 
                          puede hacerlo desde el  siguiente vínculo ";
                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/Multas.aspx?dominio=" + obj.dominio + "&nroEpediente=" + obj.NRO_EXPEDIENTE + @"'>Link para pago</a> </p>";
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
                        <title>Notificacion  de Resolucion                nro notif digital: " + obj2.nro_acta + @" </title>
                    </head>
                    <body>
                       <p> Estimado/a " + obj2.nombre_noti + @" </p>
                       <p> Nos dirigimos a usted en relacion a la Resolucion de la multa emitida con causa nro: " + obj2.nro_causa + @"/" + obj2.ANIO + @" para la cual se dictamino:</p> " +

                  @" <p>" + obj2.ART_1 + @"</p>";
                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/Multas.aspx?dominio=" + obj2.dominio + "8&nroEpediente=" + obj2.NRO_EXPEDIENTE + @"'>Link para pago</a>";
                cuerpo = cuerpo + @" <p>El horario de atención es de lunes a viernes de 7 a 13Hs.
                         Oficina ubicada en Goycoechea 686</p>
                        <p> Tel: 03543-439280 int. 321/322</p>
                         </body> </html> ";
            }

            email.Mensaje = cuerpo;
            var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);

            if (respuesta.Resultado != "OK")
            {
                _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
                return BadRequest(new { message = "Error al Notificar los datos del Cidi,verifique el nro de cuit " });
            }
            _Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
            _Notificacion_digitalService.updateSumario(nro_expediente, tipo_reporte);
            _Notificacion_digitalService.InsertarNuevoEstado(nro_expediente, id_usuario, tipo_reporte, nro_notif);
            return Ok(respuesta);
        }
        [HttpPost]
        public IActionResult enviarNotificacionGeneral([FromBody] dynamic datos)
        {

            var objeto = JsonConvert.DeserializeObject<ModeloDeDatos>(datos.ToString());
            string cuit = objeto.cuit;
            string subject = objeto.subject;
            string body = objeto.body;
            int nro_notif = 0;
            Email email = new Email();
            email.Cuil = cuit;
            email.Asunto = subject;
            email.Mensaje = body;
            email.Firma = "Administracion General";
            email.Ente = "Municipalidad de Villa Allende";
            email.Id_App = Config.CiDiIdAplicacion;
            email.Pass_App = Config.CiDiPassAplicacion;
            email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
            var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
            nro_notif = _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, 6, 0, 0, 0, 0);
            if (respuesta.Resultado != "OK")
            {
                _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            _Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult enviarNotificacionProcuracion([FromBody] dynamic datos)
        {

            var objeto = JsonConvert.DeserializeObject<ModeloProcuracion>(datos.ToString());
            string cuit = objeto.cuit;
            string subject = objeto.subject;
            string body = objeto.body;
            string tituloReporte = objeto.tituloReporte;
            int Nro_Emision = objeto.nro_emision;
            int Nro_Notificacion = objeto.nro_notificacion;
            int nro_procuracion = objeto.nro_procuracion;
            int id_oficina = objeto.id_oficina;
            int id_usuario = objeto.id_usuario;
            int tipo_proc = objeto.tipo_proc;
            int cod_estado_actual = objeto.cod_estado_actual;
            int nro_notif = 0;
            string cuerpo = "";
            string nombre = "";
            string dominio = "";
            int legajo;
            string nro_catastral = "";
            if (tipo_proc == 1)
            {
                Det_notificacion_estado_proc_inm objDet = new Det_notificacion_estado_proc_inm();
                objDet = _Det_notificacion_estado_proc_inmService.getByPk(Nro_Emision, Nro_Notificacion);
                nombre = objDet.Nombre;
                nro_catastral = objDet.Circunscripcion.ToString() + "-" + objDet.Seccion.ToString() + "-" + objDet.Manzana.ToString() + "-" + objDet.Parcela.ToString() + "-" + objDet.P_h.ToString();
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> IMPUESTO INMOBILIARIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           < p> Estimado/a: " + objDet.Nombre + @"  titular del inmueble: " + nro_catastral + @" con procuracion: " + objDet.Nro_procuracion + @"</p>
                           <p> " + body + @"  </p>";

                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_procuracion + "&cir=" + objDet.Circunscripcion + "&sec=" + objDet.Seccion + "&man=" + objDet.Manzana + "&par=" + objDet.Parcela + "&ph=" + objDet.P_h + @"'>Link para pago</a>";

                cuerpo = cuerpo + @" <p>El horario de atención es de lunes a viernes de 7 a 13Hs.
                         Oficina ubicada en Goycoechea 686</p>
                        <p> Tel: 03543-439280 int. 321/322</p>
                         </body> </html> ";



            }
            if (tipo_proc == 3)
            {
                Det_notificacion_estado_proc_iyc objDet = new Det_notificacion_estado_proc_iyc();
                objDet = _Det_notificacion_estado_proc_iycService.getByPk(Nro_Emision, Nro_Notificacion);
                nombre = objDet.Nombre;
                legajo = objDet.Legajo;
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> INDUSTRIA Y COMERCIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           <p> Estimado/a: " + objDet.Nombre + @"  titular del comercio con Legajo: " + objDet.Legajo + @" con procuracion: " + objDet.Nro_Procuracion + @"</p>
                           <p> " + body + @"  </p>";

                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionIYC.aspx?nroProc=" + objDet.Nro_Procuracion + "&legajo=" + objDet.Legajo + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";
                //if (cod_estado_actual == 76)
                //{
                //    cuerpo = cuerpo + @"
                //             <div style='text-align: right;'>
                //               <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
                //             </div>";
                //}
                cuerpo = cuerpo + @"      </body> </html> ";
            }
            if (tipo_proc == 4)
            {
                Det_notificacion_estado_proc_auto objDet = new Det_notificacion_estado_proc_auto();
                objDet = _Det_notificacion_estado_proc_autoService.getByPk(Nro_Emision, Nro_Notificacion);
                nombre = objDet.Nombre;
                dominio = objDet.Dominio;
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " +
                           objeto.tituloReporte + @" </u> </p>""
                           <p> IMPUESTO AUTOMOTOR - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           <p> Estimado/a: " + objDet.Nombre + @"  titular del Dominio: " +
                           objDet.Dominio + @" con procuracion: " +
                           objDet.Nro_Procuracion + @"</p>
                           <p> " + body + @"  </p>";

                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_Procuracion + "&dominio=" + objDet.Dominio + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";


                //if (cod_estado_actual == 76)
                //{
                //    cuerpo = cuerpo + @"
                //             <div style='text-align: right;'>
                //               <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
                //             </div>";
                //}



                cuerpo = cuerpo + @"      </body> </html> ";

            }
            string hash = "";

            if (Request.Headers.TryGetValue("hash", out var Hash))
            {
                hash = Hash.ToString();
                Email email = new Email();
                email.HashCookie = hash;// "34424C56707A693148527047383346625765504F30753058597A593D";
                email.Cuil = cuit;
                email.Asunto = "Procuración administrativa Municipalidad de Villa Allende";//subject;
                email.Mensaje = cuerpo;
                email.Firma = "Oficina de Recursos Tributarios";
                email.Ente = "Municipalidad de Villa Allende";
                email.Id_App = Config.CiDiIdAplicacion;
                email.Pass_App = Config.CiDiPassAplicacion;
                email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
                var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
                nro_notif = _Notificacion_digitalService.insertNotifProc(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion);
                if (respuesta.Resultado != "OK")
                {
                    _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
                    return BadRequest(new { message = "Error al obtener los datos" });
                }
                _Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
                _Notificacion_digitalService.updateProcuracion(nro_procuracion, tipo_proc, Nro_Notificacion, Nro_Emision, cod_estado_actual);
                _Notificacion_digitalService.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, nro_notif, id_usuario, cod_estado_actual);
            }
            return Ok();//Ok(respuesta);
        }
        [HttpPost]
        public IActionResult enviarNotificacionProcuracionNuevas([FromBody] dynamic datos)
        {

            var objeto = JsonConvert.DeserializeObject<ModeloProcuracion>(datos.ToString());
            string cuit = objeto.cuit;
            string subject = objeto.subject;
            string body = objeto.body;
            string tituloReporte = objeto.tituloReporte;
            int Nro_Emision = objeto.nro_emision;
            int Nro_Notificacion = objeto.nro_notificacion;
            int nro_procuracion = objeto.nro_procuracion;
            int id_oficina = objeto.id_oficina;
            int id_usuario = objeto.id_usuario;
            int tipo_proc = objeto.tipo_proc;
            int cod_estado_actual = objeto.cod_estado_actual;
            int nro_notif = 0;
            string cuerpo = "";
            string nombre = "";
            string dominio = "";
            int legajo = 0;
            string nro_catastral = "";


            if (tipo_proc == 1)
            {
                Det_notificacion_estado_proc_inm objDet = new Det_notificacion_estado_proc_inm();
                objDet = _Det_notificacion_estado_proc_inmService.getByPk(Nro_Emision, Nro_Notificacion);
                nombre = objDet.Nombre;
                nro_catastral = objDet.Circunscripcion.ToString() + "-" + objDet.Seccion.ToString() + "-" + objDet.Manzana.ToString() + "-" + objDet.Parcela.ToString() + "-" + objDet.P_h.ToString();
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> IMPUESTO INMOBILIARIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           < p> Estimado/a: " + objDet.Nombre + @"  titular del inmueble: " + nro_catastral + @" con procuracion: " + objDet.Nro_procuracion + @"</p>
                           <p> " + body + @"  </p>";

                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_procuracion + "&cir=" + objDet.Circunscripcion + "&sec=" + objDet.Seccion + "&man=" + objDet.Manzana + "&par=" + objDet.Parcela + "&ph=" + objDet.P_h + @"'>Link para pago</a>";

                cuerpo = cuerpo + @" <p>El horario de atención es de lunes a viernes de 7 a 13Hs.
                         Oficina ubicada en Goycoechea 686</p>
                        <p> Tel: 03543-439280 int. 321/322</p>
                         </body> </html> ";
            }
            if (tipo_proc == 3)
            {
                Det_notificacion_estado_proc_iyc objDet = new Det_notificacion_estado_proc_iyc();
                objDet = _Det_notificacion_estado_proc_iycService.getByPk(Nro_Emision, Nro_Notificacion);
                nombre = objDet.Nombre;
                legajo = objDet.Legajo;
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> INDUSTRIA Y COMERCIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           <p> Estimado/a: " + objDet.Nombre + @"  titular del Comercio con Legajo: " + objDet.Legajo + @" con procuracion: " + objDet.Nro_Procuracion + @"</p>
                           <p> " + body + @"  </p>";
                if (tipo_proc == 4)
                {
                    cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_Procuracion + "&dominio=" + objDet.Legajo + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";
                }
                //if (cod_estado_actual == 76)
                //{
                //    //cuerpo = cuerpo + @"
                //    //         <div style='text-align: right;'>
                //    //           <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
                //    //         </div>";
                //    cuerpo = cuerpo + @"";
                //}
                cuerpo = cuerpo + @"      </body> </html> ";
            }
            if (tipo_proc == 4)
            {
                Det_notificacion_auto objDet = new Det_notificacion_auto();
                objDet = _Det_notificacion_autoService.getByPk(Nro_Emision, Nro_Notificacion);
                nombre = objDet.Nombre;
                dominio = objDet.Dominio;
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> IMPUESTO AUTOMOTOR - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           <p> Estimado/a: " + objDet.Nombre + @"  titular del Dominio: " + objDet.Dominio + @" con procuracion: " + objDet.Nro_proc + @"</p>
                           <p> " + body + @"  </p>";
                if (tipo_proc == 4)
                {

                    cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_proc + "&dominio=" + objDet.Dominio + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";

                }
                if (cod_estado_actual == 76)
                {
                    //cuerpo = cuerpo + @"
                    //         <div style='text-align: right;'>
                    //           <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
                    //         </div>";
                    cuerpo = cuerpo + @"";
                }
                cuerpo = cuerpo + @"      </body> </html> ";
            }

            string hash = "";
            if (Request.Headers.TryGetValue("hash", out var Hash))
            {
                hash = Hash.ToString();
                Email email = new Email();
                email.HashCookie = hash;// "34424C56707A693148527047383346625765504F30753058597A593D";
                email.Cuil = cuit;
                email.Asunto = "Recursos Tributarios - Villa Allende";//subject;
                email.Mensaje = cuerpo;
                email.Firma = "Oficina de Recursos Tributarios";
                email.Ente = "Municipalidad de Villa Allende";
                email.Id_App = Config.CiDiIdAplicacion;
                email.Pass_App = Config.CiDiPassAplicacion;
                email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
                var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
                nro_notif = _Notificacion_digitalService.insertNotifProc(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion);
                if (respuesta.Resultado != "OK")
                {
                    _Notificacion_digitalService.update(nro_notif, 2, email.Mensaje);
                    return BadRequest(new { message = "Error al obtener los datos" });
                }
                _Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
                _Notificacion_digitalService.updateProcuracionNueva(nro_procuracion, tipo_proc, Nro_Notificacion, Nro_Emision, cod_estado_actual);
                _Notificacion_digitalService.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, nro_notif, id_usuario, cod_estado_actual);
            }
                return Ok();//(respuesta);
        }

        [HttpPost]
        public IActionResult enviarNotificacionRebeldia(int id_notificacion, string cuit, DateTime fecha)
        {

            string body = " ";
            string fechaTexto = fecha.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            string fechahoy = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            body =
                  @" <html>                  
                      <body>                  
                        <p> JUZGADO ADMINISTRATIVO DE FALTAS </p> 
                        <p> Villa Allende, " + fechahoy + @". Atento la cédula de notificación que antecede donde 
                         consta que el infractor ha sido legalmente notificado con fecha " + fechaTexto + @", sin que el
                         mismo haya ejercitado la defensa que hace a su derecho, y siendo que se encuentra vencido largamente
                         el plazo que para hacerlo tenía, declárese rebelde al mismo (arts. 18, 28 último párrafo, 
                         34 y ccds. Ordenanza 04/12 y su modificatoria) 
                         Si acepta la infracción y desea abonarla con los descuentos previstos a tal fin, 
                         puede hacerlo desde el  siguiente vínculo</p>
                      </body>
                    </html> ";
            int nro_notif = 0;
            Email email = new Email();
            email.Cuil = cuit;
            email.Asunto = " NOTIFICACION DE REBELDIA";
            email.Mensaje = body;
            email.Firma = "Juzgado de Faltas";
            email.Ente = "Municipalidad de Villa Allende";
            email.Id_App = Config.CiDiIdAplicacion;
            email.Pass_App = Config.CiDiPassAplicacion;
            email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
            var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
            nro_notif = _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, 6, 0, 0, 0, 0);
            if (respuesta.Resultado != "OK")
            {
                _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            _Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult enviarNotificacionResolRebeldia(string cuit, int id_tipo_notif, int id_oficina, int id_usuario, int tipo_reporte, int nro_expediente)
        {

            // string fechaTexto = fecha.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            string fechahoy = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            string body =
                  @" <html>                  
                      <body>                  
                        <p> JUZGADO ADMINISTRATIVO DE FALTAS </p> 
                        <p> Villa Allende, " + fechahoy + @". Atento la cédula de notificación que antecede donde </p>
                        <p> consta que el infractor ha sido legalmente notificado  sin que el</p>
                        <p> mismo haya ejercitado la defensa que hace a su derecho, y siendo que se encuentra vencido largamente</p> 
                        <p> el plazo que para hacerlo tenía, declárese rebelde al mismo (arts. 18, 28 último párrafo, </p>
                        <p> 34 y ccds. Ordenanza 04/12 y su modificatoria) </p>
                        <p> Si acepta la infracción y desea abonarla con los descuentos previstos a tal fin, </p>
                        <p> Que con fecha 8 de julio de 2023 se decretó la rebeldía del  infraccionado/a</p>
                        <p> lo que constituye un agravante en la condición procesal de la misma.</p>
                      </body>
                    </html> ";
            int nro_notif = 0;

            var cookieValue = Request.Cookies["VA.CiDi"];
            string hash = "";
            if (cookieValue != null)
            {
                var cookieValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(cookieValue);

                // Acceder a valores específicos
                if (cookieValues.TryGetValue("SesionHash", out var userName))
                {
                    // Aquí puedes usar el valor de "UserName"
                    hash = userName;
                }

            }
            Email email = new Email();
            email.HashCookie = hash;
            email.Cuil = cuit;
            email.Asunto = "NOTIFICACION DE RESOLUCION DE REBELDIA";
            email.Mensaje = body;
            email.Firma = "Juzgado de Faltas";
            email.Ente = "Municipalidad de Villa Allende";
            email.Id_App = Config.CiDiIdAplicacion;
            email.Pass_App = Config.CiDiPassAplicacion;
            email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
            var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
            nro_notif = _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, 7, id_oficina, id_usuario, 0, nro_expediente);
            if (respuesta.Resultado != "OK")
            {
                _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            _Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
            return Ok(respuesta);
        }
        [HttpPost]
        public IActionResult enviarNotificacionDelphi([FromBody] dynamic datos)
        {

            var objeto = JsonConvert.DeserializeObject<ModeloDelphi>(datos.ToString());
            string cuit = objeto.cuit;
            string id_oficina = objeto.id_oficina;
            string id_usuario = objeto.id_usuario;
            int nro_notif = 0;
            Email email = new Email();
            email.Cuil = cuit;
            //email.Asunto = subject;
            //email.Mensaje = body;
            //email.Firma = "Administracion General";
            //email.Ente = "Municipalidad de Villa Allende";
            //email.Id_App = Config.CiDiIdAplicacion;
            //email.Pass_App = Config.CiDiPassAplicacion;
            //email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
            //var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
            //nro_notif = _Notificacion_digitalService.insertNotif(cuit, email.Asunto, email.Mensaje, 6, 0, 0, 0, 0);
            //if (respuesta.Resultado != "OK")
            //{
            //    _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
            //    return BadRequest(new { message = "Error al obtener los datos" });
            //}
            //_Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
            return Ok("llego ok");
        }
        ///////////////////////////////////////////////////////////////////////
        ///
        //[HttpPost]
        //public IActionResult enviarNotificacionProcuracioniyc([FromBody] dynamic datos)
        //{

        //    var objeto = JsonConvert.DeserializeObject<ModeloProcuracion>(datos.ToString());
        //    string cuit = objeto.cuit;
        //    string subject = objeto.subject;
        //    string body = objeto.body;
        //    string tituloReporte = objeto.tituloReporte;
        //    int Nro_Emision = objeto.nro_emision;
        //    int Nro_Notificacion = objeto.nro_notificacion;
        //    int nro_procuracion = objeto.nro_procuracion;
        //    int id_oficina = objeto.id_oficina;
        //    int id_usuario = objeto.id_usuario;
        //    int tipo_proc = objeto.tipo_proc;
        //    int cod_estado_actual = objeto.cod_estado_actual;
        //    int nro_notif = 0;
        //    string cuerpo = "";
        //    string nombre = "";
        //    string dominio = "";
        //    string legajo = "";


        //    if (tipo_proc == 3)
        //    {
        //        Det_notificacion_estado_proc_iyc objDet = new Det_notificacion_estado_proc_iyc();
        //        objDet = _Det_notificacion_estado_proc_iycService.getByPk(Nro_Emision, Nro_Notificacion);
        //        nombre = objDet.Nombre;
        //        legajo = objDet.Legajo.ToString();
        //        cuerpo = @"<html>                    
        //                   <body>
        //                   <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
        //                   <p> INDUSTRIA Y COMERCIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
        //                   <p> Estimado/a: " + objDet.Nombre + @"  titular del comercio " + objDet.nombre_fantasia + @" con Legajo :" + objDet.Legajo + @" con procuracion: " + objDet.Nro_Procuracion + @"</p>
        //                   <p> " + body + @"  </p>";

        //        cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionIYC.aspx?nroProc=" + objDet.Nro_Procuracion + "&legajo=" + objDet.Legajo + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";
        //        if (cod_estado_actual == 76)
        //        {
        //            cuerpo = cuerpo + @"
        //                     <div style='text-align: right;'>
        //                       <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
        //                     </div>";
        //        }
        //        cuerpo = cuerpo + @"</body> </html> ";
        //    }


        //    Email email = new Email();
        //    email.Cuil = cuit;
        //    email.Asunto = "Procuración administrativa Municipalidad de Villa Allende";//subject;
        //    email.Mensaje = cuerpo;
        //    email.Firma = "Oficina de Recursos Tributarios";
        //    email.Ente = "Municipalidad de Villa Allende";
        //    email.Id_App = Config.CiDiIdAplicacion;
        //    email.Pass_App = Config.CiDiPassAplicacion;
        //    email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //    email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
        //    var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);

        //    nro_notif = _Notificacion_digitalService.insertNotifProc(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion);
        //    if (respuesta.Resultado != "OK")
        //    {
        //        _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    _Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
        //    _Notificacion_digitalService.updateProcuracion(nro_procuracion, tipo_proc, Nro_Notificacion, Nro_Emision, cod_estado_actual);
        //    _Notificacion_digitalService.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, nro_notif, id_usuario, cod_estado_actual);

        //    return Ok();//Ok(respuesta);
        //}

        //[HttpPost]
        //public IActionResult enviarNotificacionProcuracionNuevasIYC([FromBody] dynamic datos)
        //{

        //    var objeto = JsonConvert.DeserializeObject<ModeloProcuracion>(datos.ToString());
        //    string cuit = objeto.cuit;
        //    string subject = objeto.subject;
        //    string body = objeto.body;
        //    string tituloReporte = objeto.tituloReporte;
        //    int nro_emision = objeto.nro_emision;
        //    int nro_notificacion = objeto.nro_notificacion;
        //    int nro_procuracion = objeto.nro_procuracion;
        //    int id_oficina = objeto.id_oficina;
        //    int id_usuario = objeto.id_usuario;
        //    int tipo_proc = objeto.tipo_proc;
        //    int cod_estado_actual = objeto.cod_estado_actual;
        //    int nro_notif = 0;
        //    string cuerpo = "";
        //    string nombre = "";
        //    string dominio = "";
        //    int legajo = 0;
        //    int subsistema = tipo_proc;
        //    string nro_catastral = "";

        //    if (tipo_proc == 1)
        //    {
        //        Det_notificacion_estado_proc_inm objDet = new Det_notificacion_estado_proc_inm();
        //        objDet = _Det_notificacion_estado_proc_inmService.getByPk(nro_emision, nro_notificacion);
        //        nombre = objDet.Nombre;
        //        nro_catastral = objDet.Circunscripcion.ToString() + "-" + objDet.Seccion.ToString() + "-" + objDet.Manzana.ToString() + "-" + objDet.Parcela.ToString() + "-" + objDet.P_h.ToString();
        //        cuerpo = @"<html>                    
        //                   <body>
        //                   <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
        //                   <p> IMPUESTO INMOBILIARIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
        //                   < p> Estimado/a: " + objDet.Nombre + @"  titular del inmueble: " + nro_catastral + @" con procuracion: " + objDet.Nro_procuracion + @"</p>
        //                   <p> " + body + @"  </p>";

        //        cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_procuracion + "&cir=" + objDet.Circunscripcion + "&sec=" + objDet.Seccion + "&man=" + objDet.Manzana + "&par=" + objDet.Parcela + "&ph=" + objDet.P_h + @"'>Link para pago</a>";

        //        cuerpo = cuerpo + @" <p>El horario de atención es de lunes a viernes de 7 a 13Hs.
        //                 Oficina ubicada en Goycoechea 686</p>
        //                <p> Tel: 03543-439280 int. 321/322</p>
        //                 </body> </html> ";

        //    }
        //    if (tipo_proc == 3)
        //    {
        //        Det_notificacion_estado_proc_iyc objDet = new Det_notificacion_estado_proc_iyc();
        //        objDet = _Det_notificacion_estado_proc_iycService.getByPk(nro_emision, nro_notificacion);
        //        nombre = objDet.Nombre;
        //        legajo = objDet.Legajo;
        //        cuerpo = @"<html>                    
        //                   <body>
        //                   <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
        //                   <p> INDUSTRIA Y COMERCIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
        //                   <p> Estimado/a: " + objDet.Nombre + @"  titular del Comercio :" + objDet.nombre_fantasia + ", Legajo: " + objDet.Legajo + @" con procuracion: " + objDet.Nro_Procuracion + @"</p>
        //                   <p> " + body + @"  </p>";
        //        if (tipo_proc == 4)
        //        {
        //            cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_Procuracion + "&dominio=" + objDet.Legajo + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";
        //        }
        //        if (cod_estado_actual == 76)
        //        {
        //            cuerpo = cuerpo + @"
        //                     <div style='text-align: right;'>
        //                       <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
        //                     </div>";
        //        }
        //        cuerpo = cuerpo + @"      </body> </html> ";
        //    }

        //    if (tipo_proc == 4)
        //    {
        //        Det_notificacion_auto objDet = new Det_notificacion_auto();
        //        objDet = _Det_notificacion_autoService.getByPk(nro_emision, nro_notificacion);
        //        nombre = objDet.Nombre;
        //        dominio = objDet.Dominio;
        //        cuerpo = @"<html>                    
        //                   <body>
        //                   <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
        //                   <p> IMPUESTO AUTOMOTOR - MUNICIPALIDAD DE VILLA ALLENDE </p>
        //                   <p> Estimado/a: " + objDet.Nombre + @"  titular del Dominio: " + objDet.Dominio + @" con procuracion: " + objDet.Nro_proc + @"</p>
        //                   <p> " + body + @"  </p>";
        //        if (tipo_proc == 4)
        //        {

        //            cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_proc + "&dominio=" + objDet.Dominio + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";

        //        }
        //        if (cod_estado_actual == 76)
        //        {
        //            cuerpo = cuerpo + @"
        //                     <div style='text-align: right;'>
        //                       <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
        //                     </div>";
        //        }

        //        cuerpo = cuerpo + @"      </body> </html> ";

        //    }

        //    Email email = new Email();
        //    email.Cuil = cuit;
        //    email.Asunto = "Recursos Tributarios - Villa Allende";//subject;
        //    email.Mensaje = cuerpo;
        //    email.Firma = "Oficina de Recursos Tributarios";
        //    email.Ente = "Municipalidad de Villa Allende";
        //    email.Id_App = Config.CiDiIdAplicacion;
        //    email.Pass_App = Config.CiDiPassAplicacion;
        //    email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //    email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
        //    var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
        //    //nro_notif = _Notificacion_digitalService.insertNotifProc(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion);
        //    //if (respuesta.Resultado != "OK")
        //    //{
        //    //    _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
        //    //    return BadRequest(new { message = "Error al obtener los datos" });
        //    //}
        //    //_Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
        //    //_Notificacion_digitalService.updateProcuracionNueva(nro_procuracion, tipo_proc, Nro_Notificacion, Nro_Emision, cod_estado_actual);
        //    //_Notificacion_digitalService.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, nro_notif, id_usuario, cod_estado_actual);


        //    if (respuesta.Resultado != "OK")
        //    {
        //        _Notificacion_digitalService.NotificaProcuracionMasiva(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion,
        //            subsistema, nro_emision, cod_estado_actual);
        //    }
        //    else
        //    {
        //        _Notificacion_digitalService.NotificaProcuracionMasiva(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 1, nro_procuracion,
        //                           subsistema, nro_emision, cod_estado_actual);
        //    }


        //    //public void NotificaProcuracionMasiva(string cuil, string subject, string body, int id_tipo_notificacion, int id_oficina, int id_usuario, int cod_estado_inicial,
        //    //int nro_procuracion, int subsistema, int nro_emision, int cod_estado_actual)
        //    return Ok();//(respuesta);
        //}

        [HttpPost]
        public IActionResult enviarNotificacionProcuracionNuevasIYC([FromBody] dynamic datos)
        {
            var objeto = JsonConvert.DeserializeObject<ModeloProcuracion>(datos.ToString());
            string cuit = objeto.cuit;
            string subject = objeto.subject;
            string body = objeto.body;
            string tituloReporte = objeto.tituloReporte;
            int nro_emision = objeto.nro_emision;
            int nro_notificacion = objeto.nro_notificacion;
            int nro_procuracion = objeto.nro_procuracion;
            int id_oficina = objeto.id_oficina;
            int id_usuario = objeto.id_usuario;
            int tipo_proc = objeto.tipo_proc;
            int cod_estado_actual = objeto.cod_estado_actual;
            //int nro_notif = 0;
            string cuerpo = "";
            string nombre = "";
            string dominio = "";
            int legajo = 0;
            int subsistema = tipo_proc;
            string nro_catastral = "";

            if (subsistema == 1)
            {
                Det_notificacion_estado_proc_inm objDet = new Det_notificacion_estado_proc_inm();
                objDet = _Det_notificacion_estado_proc_inmService.getByPk(nro_emision, nro_notificacion);
                nombre = objDet.Nombre;
                nro_catastral = objDet.Circunscripcion.ToString() + "-" + objDet.Seccion.ToString() + "-" + objDet.Manzana.ToString() + "-" + objDet.Parcela.ToString() + "-" + objDet.P_h.ToString();
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> IMPUESTO INMOBILIARIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           < p> Estimado/a: " + objDet.Nombre + @"  titular del inmueble: " + nro_catastral + @" con procuracion: " + objDet.Nro_procuracion + @"</p>
                           <p> " + body + @"  </p>";

                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_procuracion + "&cir=" + objDet.Circunscripcion + "&sec=" + objDet.Seccion + "&man=" + objDet.Manzana + "&par=" + objDet.Parcela + "&ph=" + objDet.P_h + @"'>Link para pago</a>";

                cuerpo = cuerpo + @" <p>El horario de atención es de lunes a viernes de 7 a 13Hs.
                         Oficina ubicada en Goycoechea 686</p>
                        <p> Tel: 03543-439280 int. 321/322</p>
                         </body> </html> ";

            }
            if (subsistema == 3)
            {
                Det_notificacion_estado_proc_iyc objDet = new Det_notificacion_estado_proc_iyc();
                objDet = _Det_notificacion_estado_proc_iycService.getByPk(nro_emision, nro_notificacion);
                nombre = objDet.Nombre;
                legajo = objDet.Legajo;
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> INDUSTRIA Y COMERCIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           <p> Estimado/a: " + objDet.Nombre + @"  Titular del Comercio :" + objDet.nom_fantasia + ", Legajo: " + objDet.Legajo + @" con procuracion: " + objDet.Nro_Procuracion + @"</p>
                           <p> " + body + @"  </p>";
                //if (tipo_proc == 4)
                //{
                cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionIyc.aspx?nroProc=" + objDet.Nro_Procuracion + "&legajo=" + objDet.Legajo + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";
                //}
                //if (cod_estado_actual == 76)
                //{
                //    //cuerpo = cuerpo + @"
                //    //         <div style='text-align: right;'>
                //    //           <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
                //    //         </div>";
                //    cuerpo = cuerpo + @"";
                //}
                cuerpo = cuerpo + @"      </body> </html> ";
            }

            if (subsistema == 4)
            {
                Det_notificacion_auto objDet = new Det_notificacion_auto();
                objDet = _Det_notificacion_autoService.getByPk(nro_emision, nro_notificacion);
                nombre = objDet.Nombre;
                dominio = objDet.Dominio;
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> IMPUESTO AUTOMOTOR - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           <p> Estimado/a: " + objDet.Nombre + @"  titular del Dominio: " + objDet.Dominio + @" con procuracion: " + objDet.Nro_proc + @"</p>
                           <p> " + body + @"  </p>";
                if (subsistema == 4)
                {
                    cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_proc + "&dominio=" + objDet.Dominio + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";
                }
                //if (cod_estado_actual == 76)
                //{
                //    //cuerpo = cuerpo + @"
                //    //         <div style='text-align: right;'>
                //    //           <img src='https://i.ibb.co/xssVqrZ/firma-ariana.jpg' alt='Firma'  style='width: 200px; height: 150px;'>
                //    //         </div>";
                //    cuerpo = cuerpo + @"";
                //}
                cuerpo = cuerpo + @"      </body> </html> ";
            }
            var cookieValue = Request.Cookies["VA.CiDi"];
            string hash = "";
            if (cookieValue != null)
            {
                var cookieValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(cookieValue);

                // Acceder a valores específicos
                if (cookieValues.TryGetValue("SesionHash", out var userName))
                {
                    // Aquí puedes usar el valor de "UserName"
                    hash = userName;
                }

            }

            Email email = new Email();
            email.HashCookie = hash;
            email.Cuil = cuit;
            email.Asunto = "Recursos Tributarios - Villa Allende";//subject;
            email.Mensaje = cuerpo;
            email.Firma = "Oficina de Recursos Tributarios";
            email.Ente = "Municipalidad de Villa Allende";
            email.Id_App = Config.CiDiIdAplicacion;
            email.Pass_App = Config.CiDiPassAplicacion;
            email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
            var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
            //Comento los metodos de abajo y lo reemplazo por un solo metodo que se llama
            //NotificaProcuracionMasiva y dentro hace lo que hace los 3 metodos juntos
            //y esta transaccionado
            //********************************************************************************************************************************************//
            //nro_notif = _Notificacion_digitalService.insertNotifProc(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion);
            //if (respuesta.Resultado != "OK")
            //{
            //    _Notificacion_digitalService.update(nro_notif, 0, email.Mensaje);
            //    return BadRequest(new { message = "Error al obtener los datos" });
            //}
            //_Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
            //_Notificacion_digitalService.updateProcuracionNueva(nro_procuracion, tipo_proc, Nro_Notificacion, Nro_Emision, cod_estado_actual);
            //_Notificacion_digitalService.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, nro_notif, id_usuario, cod_estado_actual);
            //********************************************************************************************************************************************//
            if (respuesta.Resultado != "OK")
                _Notificacion_digitalService.NotificaProcuracionMasiva(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion,
                    subsistema, nro_emision, cod_estado_actual);
            else
                _Notificacion_digitalService.NotificaProcuracionMasiva(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 1, nro_procuracion,
                    subsistema, nro_emision, cod_estado_actual);
            return Ok();

        }


    }
}
