using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Ecommerce.Controllers
{
    [Area("Ecommerce")]
    public class CustomerController : Controller
    {
        public IActionResult CustomerAll()
        {
            return View();
        }

        public IActionResult CustomerBilling()
        {
            return View();
        }

        public IActionResult CustomerNotifications()
        {
            return View();
        }

        public IActionResult CustomerOverview()
        {
            return View();
        }

        public IActionResult CustomerSecurity()
        {
            return View();
        }
    }
}
