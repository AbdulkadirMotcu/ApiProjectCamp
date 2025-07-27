using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WepUI.ViewComponents
{
    public class _HeadDefaulComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
