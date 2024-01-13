using Microsoft.AspNetCore.Mvc;

namespace Bizland.MVC.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       
    }
}