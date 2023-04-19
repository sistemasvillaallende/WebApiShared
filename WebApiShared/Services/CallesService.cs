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
    public class CallesService : ICallesService
    {
        public Calles getByPk(int COD_CALLE)
        {
            try
            {
                return Calles.getByPk(COD_CALLE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Calles> read()
        {
            try
            {
                return Calles.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Calles> read(int COD_BARRIO)
        {
            try
            {
                return Calles.read(COD_BARRIO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

