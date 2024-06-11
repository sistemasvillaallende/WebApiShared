using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SIIMVA_WEB.Services
{
    public interface IDet_notificacion_iycService
    {
        public List<Det_notificacion_iyc> read(int nro_emision);
        public Det_notificacion_iyc getByPk(int nro_emsion, int nro_notificacion);
        public List<Det_notificacion_iyc> listarDetalle(int nro_emision);
        public List<Det_notificacion_iyc> listarDetallexEstado(int nro_emision, int cod_estado);

        //public int insert(Det_notificacion_iyc obj);
        //public void update(Det_notificacion_iyc obj);
        //public void delete(Det_notificacion_iyc obj);
    }
}

