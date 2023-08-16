using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface IDet_notificacion_estado_proc_autoService
    {
        public List<Det_notificacion_estado_proc_auto> ListarDetalle(int nro_emision);
        public List<Det_notificacion_estado_proc_auto> ListarDetallexEstado(int nro_emision, int cod_estado);
        public Det_notificacion_estado_proc_auto getByPk(int Nro_Emision, int Nro_Notificacion);
        public int insert(Det_notificacion_estado_proc_auto obj);
        public void update(Det_notificacion_estado_proc_auto obj);
        public void delete(Det_notificacion_estado_proc_auto obj);
    }
}

