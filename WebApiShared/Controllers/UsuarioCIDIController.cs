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
    }
}
