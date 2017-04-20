using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rsi.Apps;
using rsi.Entities;

namespace rsi.Ui.Controllers
{
    public class PageElementsController : Controller
    {
        public PartialViewResult _header()
        {
            return PartialView();
        }

        public PartialViewResult _menuMain()
        {
            return PartialView();
        }

        public PartialViewResult _sliderMain()
        {
            return PartialView();
        }

        public PartialViewResult _footer()
        {
            return PartialView();
        }
    }
}