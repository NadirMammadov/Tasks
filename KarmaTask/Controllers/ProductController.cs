using Microsoft.AspNetCore.Mvc;

namespace KarmaTask.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
