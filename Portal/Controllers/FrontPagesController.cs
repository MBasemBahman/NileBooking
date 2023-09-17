using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class FrontPagesController : Controller
    {
        public IActionResult LandingPage()
        {
            return View();
        }

        public IActionResult PaymentPage()
        {
            return View();
        }

        public IActionResult PricingPage()
        {
            return View();
        }

        public IActionResult CheckoutPage()
        {
            return View();
        }

        public IActionResult HelpCenterLanding()
        {
            return View();
        }

        public IActionResult HelpCenterArticle()
        {
            return View();
        }
    }
}
