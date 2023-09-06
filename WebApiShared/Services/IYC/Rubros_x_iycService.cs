using System;
using System.Collections.Generic;
using System.Data;
using WebApiShared.Entities;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiShared.Services.IYC;

namespace WebApiShared.Services
{
    public class Rubros_x_iycService : IRubros_x_iycService
    {
        public Rubros_x_iyc getByPk(int legajo, int cod_rubro, int Nro_sucursal)
        {
            try
            {
                return Rubros_x_iyc.getByPk(legajo, cod_rubro, Nro_sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Rubros_x_iyc> read()
        {
            try
            {
                return Rubros_x_iyc.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Rubros_x_iyc obj)
        {
            try
            {
                return Rubros_x_iyc.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Rubros_x_iyc obj)
        {
            try
            {
                Rubros_x_iyc.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Rubros_x_iyc obj)
        {
            try
            {
                Rubros_x_iyc.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

