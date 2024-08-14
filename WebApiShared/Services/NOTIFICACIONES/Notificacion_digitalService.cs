using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using Microsoft.Extensions.Options;
using WebApiShared.Entities.NOTIFICACIONES;

namespace WebApiShared.Services.NOTIFICACIONES
{
    public class Notificacion_digitalService : INotificacion_digitalService
    {
        //public Notificacion_digital getByPk(int id_notificacion)
        //{
        //    try
        //    {
        //        return Notificacion_digital.getByPk(id_notificacion);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<Notificacion_digital> read()
        {
            try
            {
                return Notificacion_digital.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_digital> ListarNotificaciones()
        {
            try
            {
                return Notificacion_digital.ListarNotificaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertarNuevoEstado(int nro_expediente, int cod_usuario, int tipo_reporte, int id_notificacion)
        {
            try
            {
                return Notificacion_digital.InsertarNuevoEstado(nro_expediente, cod_usuario, tipo_reporte, id_notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertarNuevoEstadoProc(int nro_procuracion, int tipo_proc, int id_notificacion, int cod_usuario, int cod_estado)
        {
            try
            {
                return Notificacion_digital.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, id_notificacion, cod_usuario, cod_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_digital> listNotifxTipoNotif(int tipo_notificacion)
        {
            try
            {
                return Notificacion_digital.ListNotifxTipoNotif(tipo_notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_digital> ListNotifxEstado(int cod_estado)
        {
            try
            {
                return Notificacion_digital.ListNotifxEstado(cod_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Notificacion_digital> ListNotifxOficina(int cod_oficina)
        {
            try
            {
                return Notificacion_digital.ListNotifxOficina(cod_oficina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Notificacion_digital> GetOficinas(int cod_usuario)
        {
            try
            {
                return Notificacion_digital.GetOficinas(cod_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(int id_notificacion, int estado_notif, string body_notif,
            int nro_emision, int nro_notif, int nro_proc, int tipo_proc, int masivo_o_nuevo)
        {
            try
            {
                Notificacion_digital.update(id_notificacion, estado_notif, body_notif, nro_emision, nro_notif, nro_proc, tipo_proc, masivo_o_nuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateSumario(int nro_expediente, int tipo_reporte)
        {
            try
            {
                Notificacion_digital.updateSumario(nro_expediente, tipo_reporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateProcuracionNueva(int nro_procuracion, int tipo_proc, int nro_notifiicacion, int nro_emision, int cod_estado_actual)
        {
            try
            {
                Notificacion_digital.updateProcuracionNueva(nro_procuracion, tipo_proc, nro_notifiicacion, nro_emision, cod_estado_actual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateProcuracion(int nro_procuracion, int tipo_proc, int nro_notifiicacion, int nro_emision, int cod_estado_actual)
        {
            try
            {
                Notificacion_digital.updateProcuracion(nro_procuracion, tipo_proc, nro_notifiicacion, nro_emision, cod_estado_actual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_digital> ListNotifxcuil(string cuil)
        {
            try
            {
                return Notificacion_digital.ListNotifxcuil(cuil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insertNotif(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_expediente)
        {
            try
            {
                return Notificacion_digital.insertNotif(cuil, subject, body, id_tipo_notif, id_oficina, id_usuario, cod_estado, nro_expediente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertNotifProc(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_procuracion, int nro_emision)
        {
            try
            {
                return Notificacion_digital.insertNotifProc(cuil, subject, body, id_tipo_notif, id_oficina, id_usuario, cod_estado, nro_procuracion, nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Notificacion_digital obj)
        {
            try
            {
                return Notificacion_digital.insert(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void delete(Notificacion_digital obj)
        {
            try
            {
                Notificacion_digital.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Notificacion_digital getByPk()
        {
            throw new NotImplementedException();
        }

        public void NotificaProcuracionMasiva(string cuil, string subject, string body, int id_tipo_notificacion, int id_oficina, int id_usuario, int cod_estado_inicial,
            int nro_procuracion, int subsistema, int nro_emision, int cod_estado_actual)
        {
            try
            {
                int nro_notificacion = 0;
                //using (TransactionScope scope = new TransactionScope())
                //{

                    //nro_notificacion = Notificacion_digital.NotificaProcuracionMasiva(cuil, subject, body, id_tipo_notificacion, id_oficina, id_usuario, cod_estado_inicial, nro_procuracion,
                    //subsistema, nro_emision, cod_estado_actual);                   
                    //08/05/2024
                    //en el parametro cod_estado_inicial
                    //tenia un 0
                    //pero ahora traigo el valor desde la llamada del Controller enviarNotificacionProcuracionNuevasIYC
                    //por las dudas si falla lo volvemos a 0
                    //no entiendo un choto pq tenia fijo el 0.
                    //Si dsp anda bien borro todo lo comentado!
                    nro_notificacion = Notificacion_digital.insertNotifProc(cuil, subject, body, 1, id_oficina, id_usuario, cod_estado_inicial, nro_procuracion, nro_emision);
                    //Notificacion_digital.update(nro_notificacion, 0, body);
                    //_Notificacion_digitalService.update(nro_notif, 1, email.Mensaje);
                    //Falta reemplazar el metodo de arriba
                    //_Notificacion_digitalService.updateProcuracion(nro_procuracion, tipo_proc, Nro_Notificacion, Nro_Emision, cod_estado_actual);
                    Notificacion_digital.updateProcuracion(nro_procuracion, subsistema, nro_notificacion, nro_emision, cod_estado_actual);
                    //_Notificacion_digitalService.InsertarNuevoEstadoProc(nro_procuracion, tipo_proc, nro_notif, id_usuario, cod_estado_actual);
                    Notificacion_digital.InsertarNuevoEstadoProc(nro_procuracion, subsistema, nro_notificacion, id_usuario, cod_estado_actual);
                    
                //scope.Complete();
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int insertNotifProc(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado, int nro_procuracion)
        {
            throw new NotImplementedException();
        }
    }
}


