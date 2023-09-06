using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SIIMVA_WEB.Services
{
    public interface INotificacion_autoService
    {
        public List<Notificacion_auto> read();
        public Notificacion_auto getByPk(int Nro_emision);
        public int insert(Notificacion_auto obj);
        public void update(Notificacion_auto obj);
        public void delete(Notificacion_auto obj);
    }
}

