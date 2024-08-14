using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public class Template_notificacionService: ITemplate_notificacionService
    {
        public List<Template_notificacion> ObtenerTextoReporte(int idTemplate, int subsistema)
        {
            try
            {
                return Template_notificacion.ObtenerTextoReporte(idTemplate, subsistema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Template_notificacion> ObtenerTextoRebeldia(int nro_expediente)
        {
            try
            {
                return Template_notificacion.ObtenerTextoRebeldia(nro_expediente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}




