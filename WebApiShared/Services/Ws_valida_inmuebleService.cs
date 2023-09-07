using WebApiShared.Entities;

namespace WebApiShared.Services
{
    public class Ws_valida_inmuebleService : IWs_valida_InmuebleService
    {
        public ws_valida_inmueble getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return ws_valida_inmueble.getByPk(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
