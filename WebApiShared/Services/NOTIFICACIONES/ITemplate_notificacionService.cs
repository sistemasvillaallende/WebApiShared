using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface ITemplate_notificacionService
    {
        public List<Template_notificacion> ObtenerTextoReporte(int idTemplate);
        public List<Template_notificacion> ObtenerTextoRebeldia(int nro_expediente);
    }
}
