using WebApiShared.Entities.CIDI;
namespace WebApiShared.Services.CIDI
{
    public interface IUsuariosServices
    {
        public Entities.CIDI.Usuario ObtenerUsuario2(string HashCookie);
        public string ObtenerUsuario(string HashCookie);
    }
}
