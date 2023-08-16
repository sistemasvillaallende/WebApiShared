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
    public class Estados_procuracionService : IEstados_procuracionService
    {
        public Estados_procuracion getByPk(int codigo_estado)
        {
            try
            {
                return Estados_procuracion.getByPk(codigo_estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Estados_procuracion> ListarEstadosxNotif(int nro_emision,int subsistema)
        {
            try
            {
                return Estados_procuracion.ListarEstadosxNotif(nro_emision, subsistema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Estados_procuracion obj)
        {
            try
            {
                return Estados_procuracion.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Estados_procuracion obj)
        {
            try
            {
                Estados_procuracion.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Estados_procuracion obj)
        {
            try
            {
                Estados_procuracion.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

