using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebApiShared.Services.LOGIN;

namespace WebApiShared.Controllers
{
    [ApiController]
    //[Route("[controller]/[action]")]
    //[Route("api/[controller]/[action]")]
    [Route("[controller]/[action]")]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServices _iusuarioService;
        private readonly IUsuarioConOficina _iusuarioConOficinaService;
        private readonly IPermisoServices _ipermisoServices;
        public LoginController(IUsuarioServices iusuarioService, IUsuarioConOficina iusuarioConOficinaService, IPermisoServices ipermisoServices)
        {
            _iusuarioService = iusuarioService;
            _iusuarioConOficinaService = iusuarioConOficinaService;
            _ipermisoServices = ipermisoServices;
            
        }

        [HttpGet]
        public IActionResult readUser(string user)
        {
            var resultado = _iusuarioService.readUser(user);
            return Ok(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> ValidaUsuario(string user, string password)
        {
            var resultado = await _iusuarioService.ValidaUsuario(user, password);
            return Ok(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> ValidaPermiso(string user, string proceso)
        {
            var resultado = await _iusuarioService.ValidaPermiso(user, proceso);
            return Ok(resultado);
        }
        [HttpGet]
        public IActionResult ValidaUsuarioConOficina(string user, string password)
        {
            var resultado = _iusuarioConOficinaService.ValidUser(user, password);
            return Ok(resultado);
        }
        [HttpGet]
        public IActionResult GetPermisosCidi(int cod_usuario)
        {
            var resultado = _ipermisoServices.GetPermisosCidi(cod_usuario);
            return Ok(resultado);
        }
        [HttpGet]
        public IActionResult ValidaPermisoConOficina(string user, string proceso)
        {
            var resultado = _iusuarioConOficinaService.ValidaPermiso(user, proceso);
            return Ok(resultado);
        }

    }
}
