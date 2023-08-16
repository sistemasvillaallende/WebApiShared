using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface INotificacion_estado_proc_inmService
    {
        public List<Notificacion_estado_proc_inm> ListarNotifProcInm();
      //  public Notificacion_estado_proc_inm getByPk(int Nro_emision, DateTime Fecha_emision);
        public int insert(Notificacion_estado_proc_inm obj);
        public void update(Notificacion_estado_proc_inm obj);
        public void delete(Notificacion_estado_proc_inm obj);
    }
}

