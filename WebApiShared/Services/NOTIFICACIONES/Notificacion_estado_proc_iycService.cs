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
    public class Notificacion_estado_proc_iycService : INotificacion_estado_proc_iycService
    {
        public Notificacion_estado_proc_iyc getByPk(int Nro_Emision)
        {
            try
            {
                return Notificacion_estado_proc_iyc.getByPk(Nro_Emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_estado_proc_iyc> ListarNotifProcIyc()
        {
            try
            {
                return Notificacion_estado_proc_iyc.ListarNotifProcIyc();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Notificacion_estado_proc_iyc obj)
        {
            try
            {
                return Notificacion_estado_proc_iyc.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Notificacion_estado_proc_iyc obj)
        {
            try
            {
                Notificacion_estado_proc_iyc.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Notificacion_estado_proc_iyc obj)
        {
            try
            {
                Notificacion_estado_proc_iyc.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

