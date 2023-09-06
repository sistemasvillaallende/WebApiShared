namespace WebApiShared.Services.LOGIN
{
    public class UsuarioConOficina : IUsuarioConOficina
    {
        public Entities.LOGIN.UsuarioConOficina getByPk(int cod_usuario)
        {
            try
            {
                return Entities.LOGIN.UsuarioConOficina.getByPk(cod_usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ValidaPermiso(string User, string Proceso)
        {
            try
            {
                return Entities.LOGIN.UsuarioConOficina.ValidaPermiso(User, Proceso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Entities.LOGIN.UsuarioConOficina ValidUser(string user, string password)
        {
            try
            {
                return Entities.LOGIN.UsuarioConOficina.ValidUser(user, password);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
