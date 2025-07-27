using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WepUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
