using WebApiShared.Entities.LOGIN;
namespace WebApiShared.Services.LOGIN
{
    public interface IUsuarioServices
    {
        public Task<Usuario> readUser(string user);
        public Task<bool> ValidaUsuario(string user, string password);
        public Task<bool> ValidaPermiso(string user, string proceso);
    }

}
