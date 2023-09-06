
using System;
using System.Threading.Tasks;
using WebApiShared.Entities.LOGIN;

namespace WebApiShared.Services.LOGIN
{
    public class UsuarioServices : IUsuarioServices
    {
        public async Task<Usuario> readUser(string user)
        {
            try
            {
                return await SeguridadDal.readUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ValidaUsuario(string user, string password)
        {
            try
            {
                return await SeguridadDal.ValidaUsuario(user, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ValidaPermiso(string user, string password)
        {
            try
            {
                return await SeguridadDal.ValidaPermiso(user, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}