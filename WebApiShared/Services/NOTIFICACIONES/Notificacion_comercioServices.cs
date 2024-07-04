using SIIMVA_WEB;
using WebApiShared.Entities.NOTIFICACIONES;

namespace WebApiShared.Services.NOTIFICACIONES
{
    public class Notificacion_comercioServices:INotificacion_comercioServices
    {
        public NotificacionIndYCom getByPk(int Nro_emision)
        {
            try
            {
                return NotificacionIndYCom.getByPk(Nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NotificacionIndYCom> read()
        {
            try
            {
                return NotificacionIndYCom.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(NotificacionIndYCom obj)
        {
            try
            {
                return NotificacionIndYCom.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(NotificacionIndYCom obj)
        {
            try
            {
                NotificacionIndYCom.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(NotificacionIndYCom obj)
        {
            try
            {
                NotificacionIndYCom.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
