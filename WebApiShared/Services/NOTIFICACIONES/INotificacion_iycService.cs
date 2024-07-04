using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;

namespace SIIMVA_WEB.Services
{
    public interface INotificacion_iycService
    {
        public List<Notificacion_iyc> read();
        public Notificacion_iyc getByPk(int Nro_emision);
        public int insert(Notificacion_iyc obj);
        public void update(Notificacion_iyc obj);
        public void delete(Notificacion_iyc obj);
    }
}

