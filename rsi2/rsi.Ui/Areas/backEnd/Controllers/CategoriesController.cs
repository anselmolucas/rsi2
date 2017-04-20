/*
    controller.....: Categories
    system.........: rsi2
    descrição......: manutenção de categorias
    author.........: anselmolucas @gmail.com
    date...........: 20/abr/2017
    status.........: 0% ok
    pendências.....: 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rsi.Apps;
using rsi.Entities;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class CategoriesController : Controller
    {
        //private Context _context = new Context();
        private CategoriesApp _categoriesApp = new CategoriesApp();
        //private Functions _functions = new Functions();

        public ActionResult List()
        {
            ViewBag.Title = "cadastro de categorias";
            ViewBag.SubTitle = "lista";
            ViewBag.PreviousScreen = "home";
            ViewBag.PreviousScreenLink = "/backEnd/Admin/Index";
            ViewBag.CurrentScreen = "categorias (lista)";

            return View();
        }

        [HttpGet]
        public PartialViewResult _list()
        {
            var _list = _categoriesApp.ListAll("full");

            return PartialView(_list);
        }

        [HttpGet]
        public ActionResult Maintenance(int id, string o)
        {
            if (!String.IsNullOrEmpty(o))
            {
                if (o == "a" || o == "e" || o == "d" || o == "v")
                {
                    Category _obj = new Category();

                    if (o != "a")
                    {
                        var _obj_temp = _categoriesApp.SearchById(id);

                        if (_obj_temp == null)
                            return RedirectToAction("List", "Categories");

                        _obj = _obj_temp;
                    }

                    // form header:
                    ViewBag.FormHeaderAux = FormHeader(_obj, o);

                    // breadcrumbs:
                    ViewBag.Title = "cadastro de categorias";
                    ViewBag.PreviousScreen = "categorias (lista)";
                    ViewBag.PreviousScreenLink = "/backEnd/Categories/List";
                    ViewBag.CurrentScreen = o == "a" ? "adicionar novo registro" : o == "e" ? "editar registro" : o == "d" ? "excluir registro" : o == "v" ? "visualizar registro" : "*** operação não definida ***";

                    return View(_obj);
                }
            }

            return RedirectToAction("List", "Categories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Maintenance(Category __obj, FormCollection _formCollection)
        {
            if (ModelState.IsValid)
            {
                string _operation = Convert.ToString(_formCollection["operation"]); // string _operation = _formCollection[2];

                if (_operation == "delete")
                {
                    _categoriesApp.Delete(__obj);
                    return RedirectToAction("List");
                }
                else if (_operation == "add")
                    return RedirectToAction("Maintenance", new { id = 0, o = "a" });

                else if (_operation == "save")
                    __obj = _categoriesApp.Save(__obj);

                return RedirectToAction("Maintenance", new { id = __obj.Id, o = "e" });
            }

            return RedirectToAction("List");
        }
        
        private IDictionary<string, string> FormHeader(Category __obj, string __operation)
        {
            IDictionary<string, string> _formHeader = new Dictionary<string, string>();
            _formHeader.Add("St", __obj.St.ToString());
            _formHeader.Add("Operation", __operation);
            _formHeader.Add("Id", __obj.Id.ToString());
            _formHeader.Add("Name", Functions.__maximumSizeOfTheText(__obj.Name, 20));
            _formHeader.Add("Link", "/Search/FindKey/");
            _formHeader.Add("saveFormButtonId", "saveFormButton"); // id do botão save form
            _formHeader.Add("resetFormButtonId", "resetFormButton"); // id do botão reset form
            _formHeader.Add("resetFormButtonFunction", "resetForm()"); // função para reset form e desabilitar o botão save
            _formHeader.Add("FormId", "categoriesForm");
            _formHeader.Add("FormIdIcon", "stIconInTitle");
            _formHeader.Add("thisScreenIs", "main"); // parâmetro que determina se essa é a tala principal ou auxiliar
            _formHeader.Add("idInHeader", "idInHeader"); // id in header 
            _formHeader.Add("operationInHeader", "operationInHeader"); // operation in header
            _formHeader.Add("divIdToshowHideDeleteButtonOnClick", "deleteRegisterConfirm"); // id da div escondida para deletar efetivamente o registro
            _formHeader.Add("FormTitle", (__operation == "a" ? "incluir" :
                                            __operation == "e" ? "editar" :
                                            __operation == "v" ? "visualizar" :
                                            __operation == "d" ? "deletar" : "") + " registro"
                                        );
            return _formHeader;
        }
    }
}