/*
controller.....: Admin
system.........: rsi
descrição......: dashboard
author.........: anselmolucas@gmail.com
date...........: 01/set/2016
status.........: 0% ok (falta widgets e gráficos)
*/

using System.Web.Mvc;
using rsi.Apps;
using rsi.Entities;
using rsi.Entities.configurations;
using rsi.Ui.Filtros;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    //[AutorizacaoFilter]
    public class AdminController : Controller
    {
        private UsersApp _usersApp = new UsersApp();
        private Context _context = new Context();
        private Functions _functions = new Functions();

        public ActionResult Index()
        {
            ViewBag.Title = "home";
            ViewBag.PageTitle = "painel de controle";
            ViewBag.SubTitle = "painel de controle";

            ViewBag.PreviousScreen = "home";
            ViewBag.PreviousScreenLink = "";
            ViewBag.CurrentScreen = "dashbox";

            Session["usuarioLogado"] = _context.Users.Find(1);

            return View();
        }

        [HttpGet]
        public ActionResult DashboardV1(int id = 1)
        {
            return View();
        }

        public ActionResult DashboardV2()
        {
            return View();
        }
    }
}