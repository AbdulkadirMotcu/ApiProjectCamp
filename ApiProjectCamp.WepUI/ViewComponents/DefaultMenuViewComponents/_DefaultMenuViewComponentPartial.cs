using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WepUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
