using WebApiShared.Entities.CIDI;
namespace WebApiShared.Services.CIDI
{
    public interface IUsuariosServices
    {
        public string ObtenerUsuario(string HashCookie);
    }
}
