using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Ecommerce.Controllers
{
    [Area("Ecommerce")]
    public class OrderController : Controller
    {
        public IActionResult OrderList()
        {
            return View();
        }

        public IActionResult OrderDetails()
        {
            return View();
        }
    }
}
