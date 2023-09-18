using WebApiShared.Entities;

namespace WebApiShared.Services
{
    public interface IWs_valida_InmuebleService
    {
        public ws_valida_inmueble getByPk(int circunscripcion, int seccion, int manzana,
            int parcela, int p_h);
    }
}
