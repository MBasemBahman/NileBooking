using Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class DashboardsController : Controller
    {
        public DashboardsController()
        {
        }

        public IActionResult Analytics()
        {
            return View();
        }

        public IActionResult CRM()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}