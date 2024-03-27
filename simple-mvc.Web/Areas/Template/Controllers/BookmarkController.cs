using Microsoft.AspNetCore.Mvc;

namespace simple_mvc.Web.Areas.Template.Controllers
{
    public class BookmarkController : Controller
    {
        [Area("Template")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
