using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;

namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface IEstados_procuracionService
    {
        public List<Estados_procuracion> ListarEstadosxNotif(int nro_emision,int subsistema);
        public Estados_procuracion getByPk(int codigo_estado);
        public int insert(Estados_procuracion obj);
        public void update(Estados_procuracion obj);
        public void delete(Estados_procuracion obj);
    }
}

