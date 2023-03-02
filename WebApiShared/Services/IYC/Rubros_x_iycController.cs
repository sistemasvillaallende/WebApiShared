using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiShared.Services

namespace WebApiShared.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class Rubros_x_iycController : Controller
{
private IRubros_x_iycService _Rubros_x_iycService;
public Rubros_x_iycController (IRubros_x_iycService Rubros_x_iycService) {
_Rubros_x_iycService = Rubros_x_iycService;
}
[HttpGet]
public IActionResult getByPk(
int legajo, int cod_rubro, int Nro_sucursal)
{
var Rubros_x_iyc = _Rubros_x_iycService.getByPk(legajo, cod_rubro, Nro_sucursal);
if (Rubros_x_iyc == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Rubros_x_iyc);
}







}
}

