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
    public class Det_notificacion_estado_proc_iycService : IDet_notificacion_estado_proc_iycService
    {
        public Det_notificacion_estado_proc_iyc getByPk(int Nro_Emision, int Nro_Notificacion)
        {
            try
            {
                return Det_notificacion_estado_proc_iyc.getByPk(Nro_Emision, Nro_Notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_estado_proc_iyc> ListarDetalle(int nro_emision)
        {
            try
            {
                return Det_notificacion_estado_proc_iyc.ListarDetalle(nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_estado_proc_iyc> ListarDetallexEstado(int nro_emision, int cod_estado)
        {
            try
            {
                return Det_notificacion_estado_proc_iyc.ListarDetallexEstado(nro_emision, cod_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_estado_proc_iyc> read()
        {
            try
            {
                return Det_notificacion_estado_proc_iyc.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Det_notificacion_estado_proc_iyc obj)
        {
            try
            {
                return Det_notificacion_estado_proc_iyc.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Det_notificacion_estado_proc_iyc obj)
        {
            try
            {
                Det_notificacion_estado_proc_iyc.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Det_notificacion_estado_proc_iyc obj)
        {
            try
            {
                Det_notificacion_estado_proc_iyc.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

