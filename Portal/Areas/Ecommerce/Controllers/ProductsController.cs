using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Ecommerce.Controllers
{
    [Area("Ecommerce")]
    public class ProductsController : Controller
    {
        public IActionResult CategoryList()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult ProductAdd()
        {
            return View();
        }
    }
}
