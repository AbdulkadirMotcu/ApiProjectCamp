﻿using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WepUI.ViewComponents
{
    public class _AboutDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}
