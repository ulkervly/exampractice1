using Microsoft.AspNetCore.Mvc;

namespace Bizland.MVC.Areas.manage.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
