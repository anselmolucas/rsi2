using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rsi.Ui.Controllers
{
    public class OfertasController : Controller
    {
        [HttpGet]
        public ActionResult Detalhes(int id = 0)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Lista(int id = 0)
        {
            return View();
        }
    }
}