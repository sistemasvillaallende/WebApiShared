using System;
using System.Collections.Generic;
using System.Data;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        public int insertNotif(string cuil, string subject, string body, int id_tipo_notif, int id_oficina, int id_usuario, int cod_estado)
        {
            try
            {
                return Notificacion_digital.insertNotif(cuil,subject,body,id_tipo_notif,id_oficina,id_usuario, cod_estado);
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
                throw ex;
            }
        }
        public void update(Notificacion_digital obj)
        {
            try
            {
                Notificacion_digital.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}


