using WebApiShared.Entities.CIDI;

namespace WebApiShared.Services.CIDI
{
    public class UsuariosService : IUsuariosServices
    {
        public Usuario ObtenerUsuario(string HashCookie)
        {
            try
            {
                Entities.CIDI.Entrada entrada = new Entities.CIDI.Entrada();
                entrada.IdAplicacion = Entities.CIDI.Config.CiDiIdAplicacion;
                entrada.Contrasenia = Entities.CIDI.Config.CiDiPassAplicacion;
                entrada.HashCookie = HashCookie;
                entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                entrada.TokenValue = Entities.CIDI.Config.ObtenerToken_SHA1(entrada.TimeStamp);

                return Entities.CIDI.Config.LlamarWebAPI<Entities.CIDI.Entrada,
                    Entities.CIDI.Usuario>(Entities.CIDI.APICuenta.Usuario.Obtener_Usuario_Aplicacion, entrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
