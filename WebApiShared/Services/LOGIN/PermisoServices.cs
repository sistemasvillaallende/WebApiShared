using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiShared.Entities.LOGIN;
using WebApiShared.Entities.NOTIFICACIONES;

namespace WebApiShared.Services.LOGIN
{
    public class PermisoServices : IPermisoServices
    {
        public List<Permisos> GetPermisosCidi(int cod_usuario)
        {
            try
            {
                return Permisos.GetPermisosCidi(cod_usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
