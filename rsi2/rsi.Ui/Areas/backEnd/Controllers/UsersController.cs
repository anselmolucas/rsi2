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
    public class UsersController : Controller
    {
        private UsersApp _usersApp = new UsersApp();
        private Context _context = new Context();
        private Functions _functions = new Functions();

        public ActionResult List()
        {
            ViewBag.Title = "cadastro de usuários";
            ViewBag.SubTitle = "lista";
            ViewBag.PreviousScreen = "home";
            ViewBag.PreviousScreenLink = "/backEnd/Admin/Index";
            ViewBag.CurrentScreen = "usuários (lista)";

            var usersList = _usersApp.List();
            return View(usersList);
        }

        [HttpGet]
        public ActionResult Maintenance(int id, string o)
        {
            if (!String.IsNullOrEmpty(o))
            {
                if (o == "a" || o == "e" || o == "d" || o == "v")
                {
                    ViewBag.Title = "cadastro de usuários";
                    ViewBag.PreviousScreen = "usuários (lista)";
                    ViewBag.PreviousScreenLink = "/backEnd/Users/List";
                    ViewBag.Operation = o;
                    ViewBag.CurrentScreen = o == "a" ? "adicionar novo registro" : o == "e" ? "editar registro" : o == "d" ? "excluir registro" : o == "v" ? "visualizar registro" : "*** operação não definida ***";

                    User _obj = new User();

                    if (o != "a") // se a operação for diferente de (a)dd: novo registro                     
                        _obj = _usersApp.Search(id);
                    else
                    {
                        // se for um novo usuário criar uma senha temporária:
                        //_obj.UserPassword = String.IsNullOrEmpty(_obj.UserPassword) ? Functions.__hashCode() : _obj.UserPassword;                        
                        _obj.St = status.on;
                    }

                    if (_obj == null)
                        return RedirectToAction("List", "Users");

                    return View(_obj);
                }
            }

            return RedirectToAction("List", "Users");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Maintenance(User __obj, FormCollection _formCollection, HttpPostedFileBase __file)
        {
            string _operation = Convert.ToString(_formCollection["operation"]);
            if (_operation == "delete")
            {
                _usersApp.Delete(__obj.Id);
                return RedirectToAction("List");
            }
            else if (_operation == "add")
                return RedirectToAction("Maintenance", new { id = 0, o = "a" });

            else if (_operation == "save")
                __obj = _usersApp.Save(__obj);

            return RedirectToAction("Maintenance", new { id = __obj.Id, o = "e" });
        }

        [HttpGet]
        public ActionResult UserProfile(int id = 0)
        {
            User _user = new User();

            if (id > 0)
            {
                User _userObj = _usersApp.Search(id);

                if (_userObj != null)
                    _user = _userObj;
            }
            else
            {
                object _userActiveObj = (User)Session["usuarioLogado"];
                _user = (User)_userActiveObj;
            }

            if (_user != null)
            {
                ViewBag.Title = _user.UserLastName + ", " + _user.UserLastName;
                ViewBag.SubTitle = "perfil do usuário";
                ViewBag.PreviousScreen = "usuários (lista)";
                ViewBag.PreviousScreenLink = "/backEnd/Users/List";

                return View(_user);
            }

            return RedirectToAction("Index", "Admin");
        }

        public PartialViewResult NavBarAtiveUserIinformation()
        {
            Session["usuarioLogado"] = _context.Users.Find(4);
            object _userActiveObj = (User)Session["usuarioLogado"];

            return PartialView(_userActiveObj);
        }

        public PartialViewResult SideBarAtiveUserIinformation()
        {
            object _userActiveObj = (User)Session["usuarioLogado"];

            return PartialView(_userActiveObj);
        }

        public ViewResult ChangePassword()
        {
            object _userActiveObj = (User)Session["usuarioLogado"];



            return View(_userActiveObj);
        }

        public PartialViewResult _list()
        {
            var _list = _usersApp.List();

            return PartialView(_list);
        }
    }
}