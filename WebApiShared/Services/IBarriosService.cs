using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities;
namespace WebApiShared.Services
{
    public interface IBarriosService
    {
        public List<Barrios> read();
        public Barrios getByPk(int COD_BARRIO);
        public int insert(Barrios obj);
        public void update(Barrios obj);
        public void delete(Barrios obj);
    }
}

