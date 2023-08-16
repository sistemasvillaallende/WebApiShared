using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities;

namespace WebApiShared.Services.IYC
{
    public interface IRubros_x_iycService
    {
        public List<Rubros_x_iyc> read();
        public Rubros_x_iyc getByPk(int legajo, int cod_rubro, int Nro_sucursal);
        public int insert(Rubros_x_iyc obj);
        public void update(Rubros_x_iyc obj);
        public void delete(Rubros_x_iyc obj);
    }
}

