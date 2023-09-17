using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Apps.Controllers
{
    [Area("Apps")]
    public class InvoiceController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Preview()
        {
            return View();
        }

        public IActionResult Print()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
