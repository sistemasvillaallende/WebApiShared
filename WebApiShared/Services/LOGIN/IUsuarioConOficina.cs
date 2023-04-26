using WebApiShared.Entities.LOGIN;

namespace WebApiShared.Services.LOGIN
{
    public interface IUsuarioConOficina
    {
        public Entities.LOGIN.UsuarioConOficina ValidUser(string user, string password);
        public Entities.LOGIN.UsuarioConOficina getByPk(int cod_usuario);
        public bool ValidaPermiso(string User, string Proceso);
    }
}
