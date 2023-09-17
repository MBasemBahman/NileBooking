using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Apps.Controllers
{
    [Area("Apps")]
    public class AccessController : Controller
    {
        public IActionResult Permission()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }
    }
}
