using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Apps.Controllers
{
    [Area("Apps")]
    public class AcademyController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult MyCourse()
        {
            return View();
        }

        public IActionResult CourseDetails()
        {
            return View();
        }
    }
}
