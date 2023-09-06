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
    public class Notificacion_estado_proc_inmService : INotificacion_estado_proc_inmService
    {
        //public Notificacion_estado_proc_inm getByPk(int Nro_emision, DateTime Fecha_emision)
        //{
        //    try
        //    {
        //        return Notificacion_estado_proc_inm.getByPk(Nro_emision, Fecha_emision);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<Notificacion_estado_proc_inm> ListarNotifProcInm()
        {
            try
            {
                return Notificacion_estado_proc_inm.ListarNotifProcInm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Notificacion_estado_proc_inm obj)
        {
            try
            {
                return Notificacion_estado_proc_inm.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Notificacion_estado_proc_inm obj)
        {
            try
            {
                Notificacion_estado_proc_inm.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Notificacion_estado_proc_inm obj)
        {
            try
            {
                Notificacion_estado_proc_inm.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

