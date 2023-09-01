using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SIIMVA_WEB.Services
{
    public interface IDet_notificacion_autoService
    {
        public List<Det_notificacion_auto> read(int Nro_emision);
        public Det_notificacion_auto getByPk(int Nro_emision, int Nro_notificacion);
        public int insert(Det_notificacion_auto obj);
        public void update(Det_notificacion_auto obj);
        public void delete(Det_notificacion_auto obj);
    }
}

