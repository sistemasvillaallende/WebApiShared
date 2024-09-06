using Microsoft.AspNetCore.Mvc;

namespace WebApiShared.Controllers
{
    public class GisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
