using Microsoft.AspNetCore.Mvc;

namespace prjFinalProjectApi.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
