using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
namespace SIIMVA_WEB.Services
{
    public class Notificacion_autoService : INotificacion_autoService
    {
        public Notificacion_auto getByPk(int Nro_emision)
        {
            try
            {
                return Notificacion_auto.getByPk(Nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notificacion_auto> read()
        {
            try
            {
                return Notificacion_auto.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Notificacion_auto obj)
        {
            try
            {
                return Notificacion_auto.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Notificacion_auto obj)
        {
            try
            {
                Notificacion_auto.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Notificacion_auto obj)
        {
            try
            {
                Notificacion_auto.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

