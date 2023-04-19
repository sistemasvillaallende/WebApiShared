using WebApiShared.Entities.CIDI.Comunicacion;

namespace WebApiShared.Services.CIDI
{
    public interface IComunicacionesService
    {
        public ResultadoEmail enviarNotificacionCUIT(string CUIT, Email email);
    }
}
