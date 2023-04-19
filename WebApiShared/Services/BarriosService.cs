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
    public class BarriosService : IBarriosService
    {
        public Barrios getByPk(int COD_BARRIO)
        {
            try
            {
                return Barrios.getByPk(COD_BARRIO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Barrios> read()
        {
            try
            {
                return Barrios.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Barrios obj)
        {
            try
            {
                return Barrios.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Barrios obj)
        {
            try
            {
                Barrios.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Barrios obj)
        {
            try
            {
                Barrios.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

