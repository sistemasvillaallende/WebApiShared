using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SIIMVA_WEB.Services
{
    public interface INotificacion_iycService
    {
        public List<Notificacion_iyc> read();
        public Notificacion_iyc getByPk(int nro_emision);
        //public int insert(Notificacion_auto obj);
        //public void update(Notificacion_auto obj);
        //public void delete(Notificacion_auto obj);
    }
}

