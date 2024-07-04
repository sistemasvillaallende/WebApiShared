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
    public class Det_notificacion_iycService : IDet_notificacion_iycService
    {
        public Det_notificacion_iyc getByPk(int nro_emision, int nro_notificacion)
        {
            try
            {
                return Det_notificacion_iyc.getByPk(nro_emision, nro_notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_iyc> read(int nro_emision)
        {
            try
            {
                return Det_notificacion_iyc.read(nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_iyc> listarDetalle(int nro_emision)
        {
            try
            {
                return Det_notificacion_iyc.listarDetalle(nro_emision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Det_notificacion_iyc> listarDetallexEstado(int nro_emision, int cod_estado)
        {
            try
            {
                return Det_notificacion_iyc.listarDetallexEstado(nro_emision, cod_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int insert(Det_notificacion_iyc obj)
        {
            try
            {
                return Det_notificacion_iyc.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Det_notificacion_iyc obj)
        {
            try
            {
                Det_notificacion_iyc.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Det_notificacion_iyc obj)
        {
            try
            {
                Det_notificacion_iyc.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

