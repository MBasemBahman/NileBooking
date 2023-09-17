using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Apps.Controllers
{
    [Area("Apps")]
    public class LogisticsController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Fleet()
        {
            return View();
        }
    }
}
