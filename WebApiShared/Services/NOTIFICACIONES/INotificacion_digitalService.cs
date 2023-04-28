using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface INotificacion_digitalService
    {
        public List<Notificacion_digital> read();
     //   public Notificacion_digital getByPk();
        public List<Notificacion_digital> listNotifxTipoNotif(int tipo_notificacion);
        public List<Notificacion_digital> ListarNotificaciones();
        public List<Notificacion_digital> ListNotifxcuil(string cuil);
        public List<Notificacion_digital> ListNotifxEstado(int cod_estado);
        public int insert(Notificacion_digital obj);
        public int insertNotif(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_expediente);
        public void update(Notificacion_digital obj);
        public int InsertarNuevoEstado(int nro_expediente, int cod_usuario, int tipo_reporte);
        public void updateSumario(int nro_expediente, int tipo_reporte);
        public void delete(Notificacion_digital obj);
    }
}

