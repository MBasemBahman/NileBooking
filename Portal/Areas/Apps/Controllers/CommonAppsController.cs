using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Apps.Controllers
{
    [Area("Apps")]
    public class CommonAppsController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult Kanban()
        {
            return View();
        }

        public IActionResult Email()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }
    }
}
