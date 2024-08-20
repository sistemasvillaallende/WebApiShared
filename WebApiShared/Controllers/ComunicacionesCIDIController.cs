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
        private IDet_notificacion_iycService _det_Notificacion_IycService;


        public ComunicacionesCIDIController(IComunicacionesService ComunicacionesService, INotificacion_digitalService Notificacion_digitalService,
            IResoluciones_multasService resoluciones_multasService, IDet_notificacion_estado_proc_autoService det_Notificacion_Estado_Proc_AutoService,
            IDet_notificacion_estado_proc_inmService det_Notificacion_Estado_Proc_InmService,
            IDet_notificacion_estado_proc_iycService det_Notificacion_Estado_Proc_IycService,
            IDet_notificacion_autoService det_Notificacion_AutoService,
            IDet_notificacion_iycService det_Notificacion_IycService)

        {
            _ComunicacionesService = ComunicacionesService;
            _Notificacion_digitalService = Notificacion_digitalService;
            _Resoluciones_multasService = resoluciones_multasService;
            _Det_notificacion_estado_proc_autoService = det_Notificacion_Estado_Proc_AutoService;
            _Det_notificacion_estado_proc_inmService = det_Notificacion_Estado_Proc_InmService;
            _Det_notificacion_estado_proc_iycService = det_Notificacion_Estado_Proc_IycService;
            _Det_notificacion_autoService = det_Notificacion_AutoService;
            _det_Notificacion_IycService = det_Notificacion_IycService;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
                cuerpo = cuerpo + @"      </body> </html> ";

            }
            string hash = "";

            if (Request.Headers.TryGetValue("hash", out var Hash))
            {
                hash = Hash.ToString();
                Email email = new Email();
                email.HashCookie = hash;
                email.Cuil = cuit;// "23271734999";
                email.Asunto = "Procuración administrativa Municipalidad de Villa Allende";
                email.Mensaje = cuerpo;
                email.Firma = "Oficina de Recursos Tributarios";
                email.Ente = "Municipalidad de Villa Allende";
                email.Id_App = Config.CiDiIdAplicacion;
                email.Pass_App = Config.CiDiPassAplicacion;
                email.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                email.TokenValue = Config.ObtenerToken_SHA512(email.TimeStamp);
                var respuesta = _ComunicacionesService.enviarNotificacionCUIT(cuit, email);
                nro_notif = _Notificacion_digitalService.insertNotifProc(cuit, email.Asunto, email.Mensaje, tipo_proc, id_oficina, id_usuario, 0, nro_procuracion, Nro_Emision);
                if (respuesta.Resultado != "OK")
                {
                    _Notificacion_digitalService.update(nro_notif, 2, email.Mensaje, Nro_Emision, Nro_Notificacion, nro_procuracion, tipo_proc, 1);
                    return BadRequest(new { message = respuesta.Resultado });
                }
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
                Det_notificacion_iyc objDet = new Det_notificacion_iyc();
                objDet = _det_Notificacion_IycService.getByPk(Nro_Emision, Nro_Notificacion);
                nombre = objDet.Nombre;
                legajo = objDet.Legajo;
                cuerpo = @"<html>                    
                           <body>
                           <p style='font-size: 26px;'><u> " + objeto.tituloReporte + @" </u> </p>""
                           <p> INDUSTRIA Y COMERCIO - MUNICIPALIDAD DE VILLA ALLENDE </p>
                           <p> Estimado/a: " + objDet.Nombre + @"  titular del Comercio con Legajo: " + objDet.Legajo + @" con procuracion: " + objDet.Nro_proc + @"</p>
                           <p> " + body + @"  </p>";
                if (tipo_proc == 4)
                {
                    cuerpo = cuerpo + @" <a href='https://vecino.villaallende.gov.ar/PagosOnLine/ProcuracionAuto.aspx?nroProc=" + objDet.Nro_proc + "&dominio=" + objDet.Legajo + @"' style='font-size: 32px;'>CONSULTE DEUDA AQUI</a>";
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
                nro_notif = _Notificacion_digitalService.insertNotifProc(cuit, email.Asunto, email.Mensaje, 1, id_oficina, id_usuario, 0, nro_procuracion, Nro_Emision);
                if (respuesta.Resultado != "OK")
                {
                    _Notificacion_digitalService.update(nro_notif, 2, email.Mensaje, Nro_Emision, Nro_Notificacion, nro_procuracion, tipo_proc, 2);
                    return BadRequest(new { message = "Error al obtener los datos" });
                }
                //_Notificacion_digitalService.update(id_notif, 1, email.Mensaje);
                _Notificacion_digitalService.updateProcuracionNueva(
                    nro_procuracion, tipo_proc, Nro_Notificacion, Nro_Emision, cod_estado_actual);
                _Notificacion_digitalService.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, nro_notif, id_usuario, cod_estado_actual);
            }
            return Ok();//(respuesta);
        }

        


    }
}
