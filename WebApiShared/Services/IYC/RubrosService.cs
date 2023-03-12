using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiShared.Entities;

namespace WebApiShared.Services
{
    public class RubrosService : IRubrosService
    {
        public Rubros getByPk(int cod_rubro, int anio)
        {
            try
            {
                return Rubros.getByPk(cod_rubro, anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Rubros> read()
        {
            try
            {
                return Rubros.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Rubros obj)
        {
            try
            {
                return Rubros.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Rubros obj)
        {
            try
            {
                Rubros.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Rubros obj)
        {
            try
            {
                Rubros.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Combo> readBajoRiesgo()
        {
            try
            {
                return Rubros.readBajoRiesgo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

