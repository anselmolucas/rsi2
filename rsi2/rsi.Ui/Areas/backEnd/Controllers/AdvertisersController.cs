/*
    controller.....: Advertisers
    system.........: rsi2
    descrição......: manutenção de anunciantes
    author.........: anselmolucas @gmail.com
    date...........: 16/abr/2017
    status.........: 80% ok
    pendências.....: inserir medias
                     inserir instruções de uso/help e revisão geral e pequenos detalhes
*/

using rsi.Apps;
using rsi.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class AdvertisersController : Controller
    {
        private Context _context = new Context();
        private AdvertisersApp _advertisersApp = new AdvertisersApp();
        private Functions _functions = new Functions();

        public ActionResult List()
        {
            ViewBag.Title = "cadastro de anunciantes";
            ViewBag.SubTitle = "lista";
            ViewBag.PreviousScreen = "home";
            ViewBag.PreviousScreenLink = "/backEnd/Admin/Index";
            ViewBag.CurrentScreen = "anunciantes (lista)";

            return View();
        }

        [HttpGet]
        public ActionResult Maintenance(int id, string o)
        {
            if (!String.IsNullOrEmpty(o))
            {
                if (o == "a" || o == "e" || o == "d" || o == "v")
                {                    
                    Advertiser _obj = new Advertiser();

                    if (o != "a")
                    {
                        var _obj_temp = _advertisersApp.SearchById(id);

                        if (_obj_temp == null)
                            return RedirectToAction("List", "Advertisers");

                        _obj = _obj_temp;
                    }

                    // form header:
                    IDictionary<string, string> _formHeader = new Dictionary<string, string>();
                    _formHeader.Add("St", _obj.St.ToString());
                    _formHeader.Add("Operation", o);
                    _formHeader.Add("Id", _obj.Id.ToString());
                    _formHeader.Add("Name", Functions.__maximumSizeOfTheText(_obj.Name, 20));
                    _formHeader.Add("Link", "/Search/FindKey/");
                    _formHeader.Add("saveFormButtonId", "saveFormButton"); // id do botão save form
                    _formHeader.Add("resetFormButtonId", "resetFormButton"); // id do botão reset form
                    _formHeader.Add("resetFormButtonFunction", "resetForm()"); // função para reset form e desabilitar o botão save
                    _formHeader.Add("FormId", "advertisersForm");
                    _formHeader.Add("FormIdIcon", "stIconInTitle");
                    _formHeader.Add("thisScreenIs", "main"); // parâmetro que determina se essa é a tala principal ou auxiliar
                    _formHeader.Add("idInHeader", "idInHeader"); // id in header 
                    _formHeader.Add("operationInHeader", "operationInHeader"); // operation in header
                    _formHeader.Add("divIdToshowHideDeleteButtonOnClick", "deleteRegisterConfirm"); // id da div escondida para deletar efetivamente o registro
                    //_formHeader.Add("addButton_aux", "advComsMaintenance(0, 'a')");
                    _formHeader.Add("FormTitle", (  o == "a" ? "incluir" :
                                                    o == "e" ? "editar" :
                                                    o == "v" ? "visualizar" :
                                                    o == "d" ? "deletar" : "") + " registro"
                                                    );

                    ViewBag.FormHeader          = _formHeader;
                    ViewBag.FormHeaderAux      = _formHeader;

                    // breadcrumbs:
                    ViewBag.Title               = "cadastro de anunciantes";
                    ViewBag.PreviousScreen      = "anunciantes (lista)";
                    ViewBag.PreviousScreenLink  = "/backEnd/Advertisers/List";                    
                    ViewBag.CurrentScreen       = o == "a" ? "adicionar novo registro" : o == "e" ? "editar registro" : o == "d" ? "excluir registro" : o == "v" ? "visualizar registro" : "*** operação não definida ***";

                    ViewBag.Operation = o;

                    return View(_obj);
                }
            }

            return RedirectToAction("List", "Advertisers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Maintenance(Advertiser __obj, FormCollection _formCollection)
        {
            if (ModelState.IsValid)
            {
                string _operation = Convert.ToString(_formCollection["operation"]); // string _operation = _formCollection[2];

                if (_operation == "delete")
                {
                    _advertisersApp.Delete(__obj);
                    return RedirectToAction("List");
                }
                else if (_operation == "add")
                    return RedirectToAction("Maintenance", new { id = 0, o = "a" });

                else if (_operation == "save")
                    __obj = _advertisersApp.Save(__obj);

                return RedirectToAction("Maintenance", new { id = __obj.Id, o = "e" });
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public PartialViewResult _list()
        {
            var _list = _advertisersApp.ListAll("full");

            return PartialView(_list);
        }

        [HttpGet]
        public PartialViewResult _modalView(int __advertiserId)
        {
            Advertiser _obj = _advertisersApp.SearchById(__advertiserId, "full");


            return PartialView(_obj);
        }
    }
}