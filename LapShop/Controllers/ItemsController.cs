using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

    }
}
