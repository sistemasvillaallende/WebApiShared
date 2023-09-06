using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface INotificacion_estado_proc_iycService
    {
        public List<Notificacion_estado_proc_iyc> ListarNotifProcIyc();
        public Notificacion_estado_proc_iyc getByPk(int Nro_Emision);
        public int insert(Notificacion_estado_proc_iyc obj);
        public void update(Notificacion_estado_proc_iyc obj);
        public void delete(Notificacion_estado_proc_iyc obj);
    }
}

