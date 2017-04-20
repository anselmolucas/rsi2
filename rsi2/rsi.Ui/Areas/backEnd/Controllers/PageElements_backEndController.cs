using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rsi.Apps;
using rsi.Entities;
using rsi.Entities.configurations;
using rsi.Ui.Filtros;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    //[AutorizacaoFilter]
    public class PageElements_backEndController : Controller
    {
        private Context _context = new Context();
        private Functions _functions = new Functions();
        private CategoriesApp _categoriesApp = new CategoriesApp();
        private SubCategoriesApp _subCategoriesApp = new SubCategoriesApp();
        //private AdvertisersApp _advertisersApp = new AdvertisersApp();

        //private PageElementsApp _pageElementsApp = new PageElementsApp();

        [HttpGet]
        public ActionResult NavBar(int id = 1)
        {
            //var _usersObj = _usersApp.SearchById(id);

            //Session["UserLogged"] = _usersObj;

            //ViewBag.UserLogged = _usersObj;
            //ViewBag.UserLoggedName = _usersObj.UserFirstName;
            //ViewBag.UserLoggedImage = _usersObj.Image;

            //return View(_usersObj);
            return View();
        }

        [HttpGet]
        public ActionResult SideBarLeft(int id = 1)
        {
            //var _usersObj = _usersApp.SearchById(id);

            //Session["UserLogged"] = _usersObj;

            //ViewBag.UserLogged = _usersObj;
            //ViewBag.UserLoggedName = _usersObj.UserFirstName;
            //ViewBag.UserLoggedImage = _usersObj.Image;

            //return View(_usersObj);
            return View();
        }

        public ActionResult SideBarRight()
        {
            return View();
        }

        public ActionResult Footer()
        {
            return View();
        }
    }
}