using Web_Api_Contable.Entities;
namespace Web_Api_Contable.Services
{
    public interface IUsuarioServices
    {
        public Task<Usuario> readUser(string user);
        public Task<bool> ValidaUsuario(string user, string password);
        public Task<bool> ValidaPermiso(string user, string proceso);
    }

}
