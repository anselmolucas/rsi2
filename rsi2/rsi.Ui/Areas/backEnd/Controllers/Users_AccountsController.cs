using rsi.Apps;
using rsi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class Users_AccountsController : Controller
    {
        private UsersApp _usersApp = new UsersApp();
        private Context _context = new Context();
        private Functions _functions = new Functions();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login _loginObj)
        {
            if (ModelState.IsValid)
            {
                User _userObj = _usersApp.ValidLogin(_loginObj);

                if (_userObj != null)
                {
                    if (_userObj.St == status.on)
                    {
                        Session["usuarioLogado"] = _userObj;
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    // usuário bloqueado, solicitar ajuda do administrador 
                    {
                        ModelState.AddModelError(string.Empty, "usuário inativo, procurar administração do site!");
                        return View();
                    }
                }

                Session["usuarioLogado"] = null;
                ModelState.AddModelError(string.Empty, "usuário inexistente ou senha inválida!");
                return View();
            }

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult LogOut()
        {
            Session["usuarioLogado"] = null;
            return RedirectToAction("Login", "UserAccounts");
        }

        /// <summary>
        /// tela de alteração de senha
        /// </summary>
        /// <param name="id">recebe o UserEmail</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangePassword(string __user = "")
        {
            Login _loginObj;

            if (!String.IsNullOrEmpty(__user))
            {
                User _userObj = _context.Users.FirstOrDefault(x => x.UserEmail == __user.ToLower().Trim());
                ViewBag.UserObj = _userObj;

                _loginObj = new Login()
                {
                    UserEmail = _userObj.UserEmail
                };
            }
            else
                _loginObj = new Login();

            return View(_loginObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(Login _loginObj)
        {
            //string pass1 = _functions.__getMD5Hash("ael");
            //string pass2 = _functions.__getMD5Hash("123");
            //string pass3 = _functions.__getMD5Hash("321");
            //string pass4 = _functions.__getMD5Hash("abc");

            if (ModelState.IsValid)
            {
                User _userObj = _context.Users.FirstOrDefault(x => x.UserEmail == _loginObj.UserEmail.ToLower().Trim());

                if (_userObj != null)
                {
                    if (_userObj.St == status.on)
                    {
                        if (_functions.__getMD5Hash(_loginObj.UserOldPassword) == _functions.__getMD5Hash(_loginObj.UserPassword))
                        {
                            ModelState.AddModelError(string.Empty, "a senha nova é igual a anterior, por gentileza digitar outra!");
                            return View();
                        }
                        _userObj.UserPasswordEncryptedMD5 = _functions.__getMD5Hash(_loginObj.UserOldPassword);
                        _usersApp.Save(_userObj);

                        return RedirectToAction("Login", "UserAccounts");
                    }
                    else
                    // usuário bloqueado, solicitar ajuda do administrador 
                    {
                        ModelState.AddModelError(string.Empty, "usuário inativo, procurar administração do site!");
                        return View();
                    }
                }

                Session["usuarioLogado"] = null;
                ModelState.AddModelError(string.Empty, "usuário inexistente!");

                return View();
            }

            Session["usuarioLogado"] = null;
            ModelState.AddModelError(string.Empty, "usuário inexistente!");

            return View();
        }

        public ActionResult SendNewPassword()
        {
            Login _loginObj = new Login();

            return View(_loginObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendNewPassword(Login _loginObj)
        {
            //if (ModelState.IsValid)
            //{
            User _userObj = _context.Users.FirstOrDefault(x => x.UserEmail == _loginObj.UserEmail.ToLower().Trim());

            if (_userObj != null)
            {
                if (_userObj.St == status.on)
                {
                    // criar uma senha temporária:
                    //_userObj.UserPassword = Functions.__hashCode();
                    //_userObj.UserPasswordEncryptedMD5 = _functions.__getMD5Hash(_userObj.UserPassword);

                    _userObj = _usersApp.Save(_userObj);

                    // enviar um e-mail para o novo usuário com a senha temporária de acesso e um link para alteração da mesma
                    _usersApp.SendNewPassword(_userObj);

                    return RedirectToAction("NewPasswordSent", "UserAccounts", new { id = _userObj.Id });
                }
                else
                // usuário bloqueado, solicitar ajuda do administrador 
                {
                    ModelState.AddModelError(string.Empty, "usuário inativo, procurar administração do site!");
                    return View();
                }
                //}

                Session["usuarioLogado"] = null;
                ModelState.AddModelError(string.Empty, "usuário inexistente!");

                return View();
            }

            Session["usuarioLogado"] = null;
            ModelState.AddModelError(string.Empty, "usuário inexistente!");

            return View();
        }

        public ActionResult NewPasswordSent(int id)
        {
            User _userObj = _context.Users.Find(id);

            return View(_userObj);
        }
    }
}