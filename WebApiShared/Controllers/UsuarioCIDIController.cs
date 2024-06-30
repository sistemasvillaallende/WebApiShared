using Microsoft.AspNetCore.Mvc;
using WebApiShared.Services.CIDI;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;

namespace WebApiShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuarioCIDIController : Controller
    {
        private IUsuariosServices _usuarioService;
        public UsuarioCIDIController(IUsuariosServices usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public IActionResult ObtenerUsuarioCIDI(string Hash)
        {
            var usu =
                _usuarioService.ObtenerUsuario(Hash);
            return Ok(usu);
        }
        [HttpGet]
        public IActionResult ObtenerUsuarioCIDI2(string Hash)
        {
            var usu =
                _usuarioService.ObtenerUsuario2(Hash);

            // Definir los valores que deseas almacenar en la cookie
            var cookieValues = new Dictionary<string, string>
        {
            { "NombreFormateado", usu.NombreFormateado },
            { "CuilFormateado", usu.CuilFormateado },
            { "SesionHash",Hash }
        };

            // Serializar los valores a una cadena JSON
            var cookieValue = JsonConvert.SerializeObject(cookieValues);

            // Configurar las opciones de la cookie (opcional)
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTime.Now.AddDays(7)
            };

            // Establecer la cookie
            Response.Cookies.Append("VA.CiDi", cookieValue, cookieOptions);
            return Ok(usu);
        }
    }
}
