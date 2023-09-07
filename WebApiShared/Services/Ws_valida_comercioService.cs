using WebApiShared.Entities;

namespace WebApiShared.Services
{
    public class Ws_valida_comercioService: IWs_valida_comercioService
    {
        public ws_valida_comercio getByPk(int legajo)
        {
            try
            {
                return ws_valida_comercio.getByPk(legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
