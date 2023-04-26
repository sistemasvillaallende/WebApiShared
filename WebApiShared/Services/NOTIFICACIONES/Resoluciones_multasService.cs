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
    public class Resoluciones_multasService : IResoluciones_multasService
    {

        public Resoluciones_multas getByPk(int COD_OFICINA, int NRO_EXPEDIENTE, string NRO_RESOLUCION)
        {
            try
            {
                return Resoluciones_multas.getByPk(COD_OFICINA, NRO_EXPEDIENTE, NRO_RESOLUCION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Resoluciones_multas  GetResolucion(int NRO_EXPEDIENTE)
        {
            try
            {
                return Resoluciones_multas.GetResolucion( NRO_EXPEDIENTE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Resoluciones_multas> read()
        {
            try
            {
                return Resoluciones_multas.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Resoluciones_multas obj)
        {
            try
            {
                return Resoluciones_multas.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Resoluciones_multas obj)
        {
            try
            {
                Resoluciones_multas.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Resoluciones_multas obj)
        {
            try
            {
                Resoluciones_multas.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

