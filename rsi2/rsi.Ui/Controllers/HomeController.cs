using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rsi.Apps;
using rsi.Entities;
using rsi.Entities.configurations;
using System.Net.Mail;
using rsi.Ui.Filtros;

namespace rsi.Ui.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}