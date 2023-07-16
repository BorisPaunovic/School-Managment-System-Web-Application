using Microsoft.AspNetCore.Mvc;

namespace SchoolManagmentSystem.Controllers
{
    public class SubjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
