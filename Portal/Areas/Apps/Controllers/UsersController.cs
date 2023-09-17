using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Apps.Controllers
{
    [Area("Apps")]
    public class UsersController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Billing()
        {
            return View();
        }

        public IActionResult Connections()
        {
            return View();
        }

        public IActionResult Notifications()
        {
            return View();
        }

        public IActionResult Security()
        {
            return View();
        }
    }
}
