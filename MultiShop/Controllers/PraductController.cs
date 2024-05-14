using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Controllers
{
    public class PraductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
