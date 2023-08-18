using Microsoft.AspNetCore.Mvc;

namespace WebApiShared.Controllers
{
    public class NotificacionAutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
