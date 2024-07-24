using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface IDet_notificacion_estado_proc_iycService
    {
        public List<Det_notificacion_estado_proc_iyc> read();
        public Det_notificacion_estado_proc_iyc getByPk(int Nro_Emision, int Nro_Notificacion);
        public Det_notificacion_estado_proc_iyc getByPkNuevas(int Nro_Emision, int Nro_Notificacion);
        public int insert(Det_notificacion_estado_proc_iyc obj);
        public void update(Det_notificacion_estado_proc_iyc obj);
        public void delete(Det_notificacion_estado_proc_iyc obj);
        public List<Det_notificacion_estado_proc_iyc> ListarDetalle(int nro_emision);
        public List<Det_notificacion_estado_proc_iyc> ListarDetallexEstado(int nro_emision, int cod_estado);
    }
}

