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
    public class Det_notificacion_estado_proc_inmService : IDet_notificacion_estado_proc_inmService
    {
        public Det_notificacion_estado_proc_inm getByPk(int Nro_emision, int Nro_notificacion)
        {
            try
            {
                return Det_notificacion_estado_proc_inm.getByPk(Nro_emision, Nro_notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Det_notificacion_estado_proc_inm> ListarDetalle(int nro_emision)
        {
            try
            {
                return Det_notificacion_estado_proc_inm.ListarDetalle(nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_estado_proc_inm> ListarDetallexEstado(int nro_emision, int cod_estado)
        {
            try
            {
                return Det_notificacion_estado_proc_inm.ListarDetallexEstado(nro_emision, cod_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_estado_proc_inm> read()
        {
            try
            {
                return Det_notificacion_estado_proc_inm.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Det_notificacion_estado_proc_inm obj)
        {
            try
            {
                return Det_notificacion_estado_proc_inm.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Det_notificacion_estado_proc_inm obj)
        {
            try
            {
                Det_notificacion_estado_proc_inm.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Det_notificacion_estado_proc_inm obj)
        {
            try
            {
                Det_notificacion_estado_proc_inm.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

