using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.LOGIN;

namespace WebApiShared.Services.LOGIN
{
    public interface IPermisoServices
    {
        public List<Permisos> GetPermisosCidi(int cod_usuario);

    }
}

