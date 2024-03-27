using Microsoft.AspNetCore.Mvc;

namespace simple_mvc.Web.Areas.Template.Controllers
{
    [Area("Template")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard2()
        {
            return View();
        }
        public IActionResult Dashboard3()
        {
            return View();
        }
    }
}
