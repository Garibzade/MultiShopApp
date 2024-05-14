using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Controllers
{
    public class PagesController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
