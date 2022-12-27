using Microsoft.AspNetCore.Mvc;

namespace Administration1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
