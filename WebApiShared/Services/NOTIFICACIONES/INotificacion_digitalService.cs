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
        //public Notificacion_digital getByPk();
        public List<Notificacion_digital> listNotifxTipoNotif(int tipo_notificacion);
        public List<Notificacion_digital> ListarNotificaciones();
        public List<Notificacion_digital> ListNotifxcuil(string cuil);
        public List<Notificacion_digital> ListNotifxEstado(int cod_estado);
        public List<Notificacion_digital> ListNotifxOficina(int cod_oficina);
        public List<Notificacion_digital> GetOficinas(int cod_usuario);
        public int insert(Notificacion_digital obj);
        public int insertNotif(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_expediente);
        public void update(int id_notificacion, int estado_notif, string body_notif,
            int nro_emision, int nro_notif, int nro_proc, int tipo_proc);
        public int InsertarNuevoEstado(int nro_expediente, int cod_usuario, int tipo_reporte, int id_notificacion);
        public int InsertarNuevoEstadoProc(int nro_procuracion, int tipo_proc, int id_notificacion, int cod_usuario, int cod_estado);
        public void updateSumario(int nro_expediente, int tipo_reporte);
        public void updateProcuracion(int nro_procuracion, int tipo_proc, int nro_notifiicacion, int nro_emision, int cod_estado_actual);
        public void updateProcuracionNueva(
            int nro_procuracion, int tipo_proc, int nro_notifiicacion, int nro_emision, int cod_estado_actual);
        public int insertNotifProc(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_procuracion, int nro_emision);
        public void delete(Notificacion_digital obj);
        public void NotificaProcuracionMasiva(string cuil, string subject, string body, int id_tipo_notificacion, int id_oficina, int id_usuario, int cod_estado_inicial,
            int nro_procuracion, int subsistema, int nro_emision, int cod_estado_actual);

    }
}

