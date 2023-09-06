using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface INotificacion_estado_proc_autoService
    {
        public List<Notificacion_estado_proc_auto> ListarNotifProcAuto();
        public Notificacion_estado_proc_auto getByPk(int Nro_Emision);
        public int insert(Notificacion_estado_proc_auto obj);
        public void update(Notificacion_estado_proc_auto obj);
        public void delete(Notificacion_estado_proc_auto obj);
    }
}

