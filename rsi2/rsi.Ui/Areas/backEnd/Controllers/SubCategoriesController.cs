using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rsi.Apps;
using rsi.Entities;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class SubCategoriesController : Controller
    {
        private Context _context = new Context();
        private SubCategoriesApp _subCategoriesApp = new SubCategoriesApp();
        private Functions _functions = new Functions();

        public ActionResult List()
        {
            ViewBag.Title = "cadastro de sub-categorias";
            ViewBag.SubTitle = "lista";
            ViewBag.PreviousScreen = "home";
            ViewBag.PreviousScreenLink = "/backEnd/Admin/Index";
            ViewBag.CurrentScreen = "sub-categorias (lista)";

            return View();
        }

        [HttpGet]
        public ActionResult Maintenance(int id, string o)
        {
            if (!String.IsNullOrEmpty(o))
            {
                if (o == "a" || o == "e" || o == "d" || o == "v")
                {
                    ViewBag.Title = "cadastro de sub-categorias";
                    ViewBag.PreviousScreen = "sub-categorias (lista)";
                    ViewBag.PreviousScreenLink = "/backEnd/SubCategories/List";
                    ViewBag.Operation = o;
                    ViewBag.CurrentScreen = o == "a" ? "adicionar novo registro" : o == "e" ? "editar registro" : o == "d" ? "excluir registro" : o == "v" ? "visualizar registro" : "*** operação não definida ***";

                    SubCategory _obj = new SubCategory();

                    if (o != "a") // se a operação for diferente de (a)dd: novo registro                     
                        _obj = _subCategoriesApp.SearchById(Convert.ToInt16(id));

                    if (_obj == null)
                        return RedirectToAction("List", "SubCategories");

                    var _categoriesList = _context.Categories.Where(x => x.St == status.on).OrderBy(x => x.Name).ToList();
                    ViewBag.Ddl_Categories = new SelectList(_categoriesList, "Id", "Name", _obj.CategoryId);

                    return View(_obj);
                }
            }

            return RedirectToAction("List", "SubCategories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Maintenance(SubCategory __obj, FormCollection _formCollection)
        {
            if (ModelState.IsValid)
            {
                string _operation = Convert.ToString(_formCollection["operation"]); // string _operation = _formCollection[2];

                if (_operation == "delete")
                {
                    _subCategoriesApp.Delete(__obj);
                    return RedirectToAction("List");
                }
                else if (_operation == "add")
                    return RedirectToAction("Maintenance", new { id = 0, o = "a" });

                else if (_operation == "save")
                    __obj = _subCategoriesApp.Save(__obj);

                return RedirectToAction("Maintenance", new { id = __obj.Id, o = "e" });
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public PartialViewResult _list()
        {
            var _list = _context.SubCategories.ToList();
            List<SubCategory> _listSubCategoriesFull = new List<SubCategory>();
            foreach (var _item in _list)
            {
                SubCategory _subCategoryObjTemp = new SubCategory();
                _subCategoryObjTemp = _item;
                _subCategoryObjTemp.CategoryObj = _context.Categories.Find(_subCategoryObjTemp.CategoryId);
                _listSubCategoriesFull.Add(_subCategoryObjTemp);
            }

            return PartialView(_listSubCategoriesFull);
        }
    }
}