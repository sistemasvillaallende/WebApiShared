using WebApiShared.Entities.NOTIFICACIONES;

namespace SIIMVA_WEB.Services
{
    public interface IDet_notificacion_iycService
    {
        public List<Det_notificacion_iyc> read(int Nro_emision);
        public Det_notificacion_iyc getByPk(int Nro_emision, int Nro_notificacion);
        public int insert(Det_notificacion_iyc obj);
        public void update(Det_notificacion_iyc obj);
        public void delete(Det_notificacion_iyc obj);
        public List<Det_notificacion_iyc> listarDetalle(int Nro_emision);
        public List<Det_notificacion_iyc> listarDetallexEstado(int Nro_emision, int cod_estado);
    }
}
