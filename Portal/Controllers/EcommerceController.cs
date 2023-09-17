using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class EcommerceController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Referrals()
        {
            return View();
        }

        public IActionResult Reviews()
        {
            return View();
        }
    }
}
