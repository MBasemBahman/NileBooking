using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Ecommerce.Controllers
{
    [Area("Ecommerce")]
    public class SettingsController : Controller
    {
        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Notifications()
        {
            return View();
        }

        public IActionResult Payments()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Shipping()
        {
            return View();
        }

        public IActionResult StoreDetails()
        {
            return View();
        }
    }
}
