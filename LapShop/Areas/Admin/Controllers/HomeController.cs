
namespace LapShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        [Authorization]
        public IActionResult Index()
        {
            return View();
        }
        

    }
}
