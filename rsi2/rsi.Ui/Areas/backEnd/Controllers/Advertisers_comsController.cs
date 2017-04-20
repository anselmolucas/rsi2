using rsi.Apps;
using rsi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class Advertisers_comsController : Controller
    {
        Context _context = new Context();
        Advertisers_comsApp _advertisers_comsApp = new Advertisers_comsApp();

        [HttpGet]
        public PartialViewResult _list(int __advertiserId)
        {
            var _list = _advertisers_comsApp.ListAll("full").Where(x => x.AdvertiserId == __advertiserId).ToList().OrderBy(x=>x.DisplayOrder);
            ViewBag.AdvertiserId = __advertiserId;
            ViewBag.Icons = IconsReturn();
            var _icons = IconsReturn();

            return PartialView(_list);
        }

        [HttpGet]
        public PartialViewResult _comsMaintenanceForm(int __comsId, string __operation, int __advertiserId)
        {
            if (!String.IsNullOrEmpty(__operation))
            {
                if (__operation == "a" || __operation == "e" || __operation == "d" || __operation == "v")
                {
                    Advertiser_com _obj = new Advertiser_com();

                    _obj.AdvertiserId = __advertiserId;
                    ViewBag.AdvertiserId = __advertiserId;

                    if (__operation != "a")
                    {
                        if (__comsId > 0)
                        {
                            var _obj_temp = _context.Advertisers_coms.FirstOrDefault(x => x.Id == __comsId);
                            if (_obj_temp != null)
                                _obj = _obj_temp;
                        }
                    }

                    IDictionary<string, string> _formHeaderAux = new Dictionary<string, string>();
                    _formHeaderAux.Add("St", _obj.St.ToString());
                    _formHeaderAux.Add("Operation", __operation);
                    _formHeaderAux.Add("Id", _obj.Id.ToString());
                    _formHeaderAux.Add("Name", "meios de comunicação");
                    _formHeaderAux.Add("FormId", "comsMaintenanceForm2");
                    _formHeaderAux.Add("idInHeader", "idInHeader_coms"); // id in header 
                    _formHeaderAux.Add("operationInHeader", "operationInHeader_coms"); // operation in header
                    _formHeaderAux.Add("divIdToshowHideDeleteButtonOnClick", "deleteRegisterConfirm_coms"); // id da div escondida para deletar efetivamente o registro
                    _formHeaderAux.Add("DivId", "comsMaintenanceForm");
                    _formHeaderAux.Add("FormIdIcon", "stIconInTitle_coms");
                    _formHeaderAux.Add("resetFormButtonFunction", "resetForm_coms()"); // função para reset form e desabilitar o botão save
                    _formHeaderAux.Add("saveFormButtonId", "saveFormButton_coms"); // id do botão save form
                    _formHeaderAux.Add("resetFormButtonId", "resetFormButton_coms"); // id do botão reset form
                    _formHeaderAux.Add("thisScreenIs", "aux"); // parâmetro que determina se essa é a tala principal ou auxiliar
                    _formHeaderAux.Add("addButton_aux", "advComsMaintenance(0, 'a'," + __advertiserId.ToString() +")");                    
                    _formHeaderAux.Add("deleteButtonOnClick", "sendComsToDeleteInForm('" + _formHeaderAux["DivId"] + "', '#idInHeader_coms')"); // função e parâmetro usado no "onclick()" do botão de exclusão de registros
                    _formHeaderAux.Add("FormTitle", (__operation == "a" ? "incluir" :
                                                    __operation == "e" ? "editar" :
                                                    __operation == "v" ? "visualizar" :
                                                    __operation == "d" ? "deletar" : "") + " registro"
                                                    );
                                                             
                    ViewBag.FormHeaderAux = _formHeaderAux;                   
                    ViewBag.Operation = __operation;

                    return PartialView(_obj);
                }
            }

            return null;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _jsonComsMaintenanceFormSubmit(FormCollection dados2, Advertiser_com __obj)
        {            
            __obj = _advertisers_comsApp.Save(__obj);

            return Json(__obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult _comsView(int __comsId, string __operation)
        {
            if (!String.IsNullOrEmpty(__operation))
            {
                Advertiser_com _obj = _context.Advertisers_coms.FirstOrDefault(x => x.Id == __comsId);

                IDictionary<string, string> _formHeaderAux = new Dictionary<string, string>();
                _formHeaderAux.Add("St", _obj.St.ToString());
                _formHeaderAux.Add("Operation", __operation);
                _formHeaderAux.Add("Id", _obj.Id.ToString());
                _formHeaderAux.Add("Name", "meios de comunicação");
                _formHeaderAux.Add("DivId", "comsView"); // id da div a ser exibida
                _formHeaderAux.Add("FormIdIcon", "stIconInTitle_coms");
                _formHeaderAux.Add("idInHeader", "idInHeader_coms"); // id in header 
                _formHeaderAux.Add("saveFormButtonId", "saveFormButton_coms"); // id do botão save form
                _formHeaderAux.Add("thisScreenIs", "aux"); // parâmetro que determina se essa é a tala principal ou auxiliar
                _formHeaderAux.Add("operationInHeader", "operationInHeader_coms"); // operation in header
                _formHeaderAux.Add("deleteButtonOnClick", "sendComsToDeleteInForm('" + _formHeaderAux["DivId"] + "', '#idInHeader_coms')"); // função e parâmetro usado no "onclick()" do botão de exclusão de registros
                _formHeaderAux.Add("divIdToshowHideDeleteButtonOnClick", "deleteRegisterConfirm_coms"); // id da div escondida para deletar efetivamente o registro
                _formHeaderAux.Add("FormTitle", (__operation == "v" ? "visualizar" :
                                                    __operation == "d" ? "deletar" : "") + " registro"
                                                    );
                ViewBag.FormHeaderAux = _formHeaderAux;
                ViewBag.Operation = __operation;

                return PartialView(_obj);
            }

            return null;
        }

        public IDictionary<string, string> IconsReturn()
        {
            IDictionary<string, string> _icons = new Dictionary<string, string>();
            _icons.Add("noInformation", "fa fa-ellipsis-h");
            _icons.Add("tel", "fa fa-phone");
            _icons.Add("cel", "fa fa-mobile");
            _icons.Add("whatsapp", "fa fa-whatsapp");
            _icons.Add("email", "fa fa-envelope");
            _icons.Add("site", "fa fa-globe");
            _icons.Add("facebook", "fa fa-facebook");
            _icons.Add("twitter", "fa fa-twitter");
            _icons.Add("instagram", "fa fa-instagram");
            _icons.Add("youtube", "fa fa-youtube");
            _icons.Add("googlePlus", "fa fa-google-plus-official");
            _icons.Add("linkedin", "fa fa-linkedin");
            _icons.Add("vimeo", "fa fa-vimeo");
            _icons.Add("pinterest", "fa fa-pinterest");
            _icons.Add("flickr", "fa fa-flickr");
            _icons.Add("mySpace", "fa fa-question-circle");
            _icons.Add("soundCloud", "fa fa-soundcloud");

            return _icons;
        }

        [HttpPost]
        public JsonResult _jsonDelete(int __comsId)
        {
            bool _retorno = false;

            try
            {
                _advertisers_comsApp.Delete(__comsId);
                _retorno = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return Json(_retorno, JsonRequestBehavior.AllowGet);
        }
    }
}