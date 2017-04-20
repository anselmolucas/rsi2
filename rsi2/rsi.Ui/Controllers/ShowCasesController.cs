using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rsi.Apps;
using rsi.Entities;

namespace rsi.Ui.Controllers
{
    public class ShowCasesController : Controller
    {
        public PartialViewResult _offersCarousel()
        {
            return PartialView();
        }

        public PartialViewResult _offersCarousel2()
        {
            return PartialView();
        }

        public PartialViewResult _offerFeatured()
        {
            return PartialView();
        }

        public PartialViewResult _offersRelated()
        {
            return PartialView();
        }

        public PartialViewResult _categoriesBanners()
        {
            return PartialView();
        }
    }
}