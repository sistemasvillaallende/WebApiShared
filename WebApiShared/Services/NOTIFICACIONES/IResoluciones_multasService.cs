using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShared.Entities.NOTIFICACIONES;
namespace WebApiShared.Services.NOTIFICACIONES
{
    public interface IResoluciones_multasService
    {
        public List<Resoluciones_multas> read();
        public Resoluciones_multas getByPk(int COD_OFICINA, int NRO_EXPEDIENTE, string NRO_RESOLUCION);
        public int insert(Resoluciones_multas obj);
        public void update(Resoluciones_multas obj);
        public void delete(Resoluciones_multas obj);
        public Resoluciones_multas GetResolucion(int NRO_EXPEDIENTE);
        public Resoluciones_multas GetDatosExpedienteNotificar(int NRO_EXPEDIENTE, int tipo_reporte);
    }
}

