using Directionary.Data.Infrastructure;
using Directionary.Data.Repositories;
using Directionary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Directionary.Web.Controllers
{
    public class MenuSiteController : Controller
    {
        public IMenuService _menuService;
        public MenuSiteController(IMenuService menuService)
        {
            _menuService = menuService;

        }
        // GET: MenuSite
    
        public PartialViewResult MenuSite(string menuActive)
        {
            ViewBag.menuActiveStr = menuActive;
            var model = _menuService.GetAllByGroupId(1).ToList();
            return PartialView(model);
        }
    }
}