using Microsoft.AspNetCore.Mvc;

namespace SchoolManagmentSystem.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
