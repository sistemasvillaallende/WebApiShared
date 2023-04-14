using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities;
namespace WebApiShared.Services
{
    public interface ICallesService
    {
        public List<Calles> read();
        public List<Calles> read(int COD_BARRIO);
        public Calles getByPk(int COD_CALLE);
    }
}

