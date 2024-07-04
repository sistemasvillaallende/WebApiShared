using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiShared.Entities.NOTIFICACIONES;

namespace SIIMVA_WEB.Services
{
    public class Notificacion_iycService : INotificacion_iycService
    {
        public Notificacion_iyc getByPk(int Nro_emision)
        {
            try
            {
                return Notificacion_iyc.getByPk(Nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_iyc> read()
        {
            try
            {
                return Notificacion_iyc.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Notificacion_iyc obj)
        {
            try
            {
                return Notificacion_iyc.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Notificacion_iyc obj)
        {
            try
            {
                Notificacion_iyc.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Notificacion_iyc obj)
        {
            try
            {
                Notificacion_iyc.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

