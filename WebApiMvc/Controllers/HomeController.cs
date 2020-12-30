using Microsoft.AspNetCore.Mvc;

namespace WebApiMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
