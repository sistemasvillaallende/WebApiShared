using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities;
namespace WebApiShared.Services
{
    public interface IRubrosService
    {
        public List<Rubros> read();
        public List<Combo> readBajoRiesgo();
        public Rubros getByPk(int cod_rubro, int anio);
        public int insert(Rubros obj);
        public void update(Rubros obj);
        public void delete(Rubros obj);
    }
}

