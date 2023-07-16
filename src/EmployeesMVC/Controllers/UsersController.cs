using Microsoft.AspNetCore.Mvc;

namespace SchoolManagmentSystem.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
           return View();
           
        }
    }
}
