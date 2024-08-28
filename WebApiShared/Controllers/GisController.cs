using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Net;

namespace WebApiShared.Controllers
{
    public class GisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult BuscarParcelas(string bbox)
        {
            // Parsear el parámetro bbox recibido
            var coords = bbox.Split(',');
            if (coords.Length != 4)
            {
                // Manejar el caso de coordenadas inválidas
                return new HttpStatusCode.;
            }

            double xmin = double.Parse(coords[0]);
            double ymin = double.Parse(coords[1]);
            double xmax = double.Parse(coords[2]);
            double ymax = double.Parse(coords[3]);

            // Crear el objeto geometry en SQL Server
            string wkt = $"POLYGON(({xmin} {ymin}, {xmin} {ymax}, {xmax} {ymax}, {xmax} {ymin}, {xmin} {ymin}))";
            var bboxGeometry = geometry::STGeomFromText(wkt,
                0);

            // Llamar al método para consultar la base de datos
            var resultado = ObtenerParcelasPorBbox(bboxGeometry);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}
