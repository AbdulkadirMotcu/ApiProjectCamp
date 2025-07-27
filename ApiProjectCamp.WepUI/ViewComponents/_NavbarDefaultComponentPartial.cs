using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WepUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
