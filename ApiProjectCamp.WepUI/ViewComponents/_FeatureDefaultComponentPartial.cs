using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WepUI.ViewComponents
{
    public class _FeatureDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
