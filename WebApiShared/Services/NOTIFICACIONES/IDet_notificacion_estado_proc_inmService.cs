using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface IDet_notificacion_estado_proc_inmService
    {
        public List<Det_notificacion_estado_proc_inm> read();
        public Det_notificacion_estado_proc_inm getByPk(int Nro_emision, int Nro_notificacion);
        public int insert(Det_notificacion_estado_proc_inm obj);
        public void update(Det_notificacion_estado_proc_inm obj);
        public void delete(Det_notificacion_estado_proc_inm obj);
        public List<Det_notificacion_estado_proc_inm> ListarDetalle(int nro_emision);
        public List<Det_notificacion_estado_proc_inm> ListarDetallexEstado(int nro_emision, int cod_estado);
    }
}

