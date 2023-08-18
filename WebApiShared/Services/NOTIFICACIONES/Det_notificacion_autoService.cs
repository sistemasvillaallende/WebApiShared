using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
namespace SIIMVA_WEB.Services
{
    public class Det_notificacion_autoService : IDet_notificacion_autoService
    {
        public Det_notificacion_auto getByPk(int Nro_emision, int Nro_notificacion, string Dominio)
        {
            try
            {
                return Det_notificacion_auto.getByPk(Nro_emision, Nro_notificacion, Dominio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_auto> read()
        {
            try
            {
                return Det_notificacion_auto.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Det_notificacion_auto obj)
        {
            try
            {
                return Det_notificacion_auto.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Det_notificacion_auto obj)
        {
            try
            {
                Det_notificacion_auto.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Det_notificacion_auto obj)
        {
            try
            {
                Det_notificacion_auto.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

