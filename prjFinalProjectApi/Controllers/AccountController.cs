using Microsoft.AspNetCore.Mvc;

namespace prjFinalProjectApi.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
