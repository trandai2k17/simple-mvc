using Microsoft.AspNetCore.Mvc;

namespace simple_mvc.Web.Areas.Template.Controllers
{
    [Area("Template")]
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
