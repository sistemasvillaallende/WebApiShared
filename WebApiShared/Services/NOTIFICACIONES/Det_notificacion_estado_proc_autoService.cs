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
    public class Det_notificacion_estado_proc_autoService : IDet_notificacion_estado_proc_autoService
    {
        public Det_notificacion_estado_proc_auto getByPk(int Nro_Emision, int Nro_Notificacion)
        {
            try
            {
                return Det_notificacion_estado_proc_auto.getByPk(Nro_Emision, Nro_Notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_estado_proc_auto> ListarDetalle(int nro_emision)
        {
            try
            {
                return Det_notificacion_estado_proc_auto.ListarDetalle(nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_estado_proc_auto> ListarDetallexEstado(int nro_emision,int cod_estado)
        {
            try
            {
                return Det_notificacion_estado_proc_auto.ListarDetallexEstado(nro_emision,cod_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Det_notificacion_estado_proc_auto obj)
        {
            try
            {
                return Det_notificacion_estado_proc_auto.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Det_notificacion_estado_proc_auto obj)
        {
            try
            {
                Det_notificacion_estado_proc_auto.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Det_notificacion_estado_proc_auto obj)
        {
            try
            {
                Det_notificacion_estado_proc_auto.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

