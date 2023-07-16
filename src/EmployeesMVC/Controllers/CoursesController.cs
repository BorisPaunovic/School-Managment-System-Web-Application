using Microsoft.AspNetCore.Mvc;

namespace SchoolManagmentSystem.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
