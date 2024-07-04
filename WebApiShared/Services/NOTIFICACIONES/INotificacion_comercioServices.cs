using SIIMVA_WEB;
using WebApiShared.Entities.NOTIFICACIONES;

namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface INotificacion_comercioServices
    {
        public List<NotificacionIndYCom> read();
        public NotificacionIndYCom getByPk(int Nro_emision);
        public int insert(NotificacionIndYCom obj);
        public void update(NotificacionIndYCom obj);
        public void delete(NotificacionIndYCom obj);
    }
}
