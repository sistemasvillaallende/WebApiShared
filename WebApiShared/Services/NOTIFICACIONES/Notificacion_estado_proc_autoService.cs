using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public class Notificacion_estado_proc_autoService : INotificacion_estado_proc_autoService
    {
        public Notificacion_estado_proc_auto getByPk(int Nro_Emision)
        {
            try
            {
                return Notificacion_estado_proc_auto.getByPk(Nro_Emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_estado_proc_auto> ListarNotifProcAuto()
        {
            try
            {
                return Notificacion_estado_proc_auto.ListarNotifProcAuto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Notificacion_estado_proc_auto obj)
        {
            try
            {
                return Notificacion_estado_proc_auto.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Notificacion_estado_proc_auto obj)
        {
            try
            {
                Notificacion_estado_proc_auto.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Notificacion_estado_proc_auto obj)
        {
            try
            {
                Notificacion_estado_proc_auto.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


