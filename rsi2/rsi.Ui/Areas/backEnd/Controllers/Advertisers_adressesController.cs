using rsi.Apps;
using rsi.Entities;
using rsi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class Advertisers_adressesController : Controller
    {
        Context _context = new Context();
        Advertisers_adressesApp _advertisers_adressesApp = new Advertisers_adressesApp();

        [HttpGet]
        public PartialViewResult _list(int __advertiserId)
        {
            var _list = _advertisers_adressesApp.ListAll("full").Where(x=>x.AdvertiserId == __advertiserId).ToList();
            ViewBag.AdvertiserId = __advertiserId;

            return PartialView(_list);
        }

        [HttpGet]
        public PartialViewResult _adressesMaintenanceForm(int __addressId, string __operation, int __advertiserId)
        {
            if (!String.IsNullOrEmpty(__operation))
            {
                if (__operation == "a" || __operation == "e" || __operation == "d" || __operation == "v")
                {
                    Advertiser_address _obj = new Advertiser_address();

                    _obj.AdvertiserId = __advertiserId;
                    ViewBag.AdvertiserId = __advertiserId;

                    if (__operation != "a")
                    {
                        if (__addressId > 0)
                        {
                            var _obj_temp = _context.Advertisers_adresses.FirstOrDefault(x => x.Id == __addressId);
                            if (_obj_temp != null)
                                _obj = _obj_temp;
                        }
                    }

                    IDictionary<string, string> _formHeaderAux = new Dictionary<string, string>();
                    _formHeaderAux.Add("St", _obj.St.ToString());
                    _formHeaderAux.Add("Operation", __operation);
                    _formHeaderAux.Add("Id", _obj.Id.ToString());
                    _formHeaderAux.Add("Name", "Endereço");//-apagar
                    _formHeaderAux.Add("FormId", "addressMaintenanceForm"); 
                    _formHeaderAux.Add("DivId",  "adressesMaintenanceForm");//-apagar
                    _formHeaderAux.Add("FormIdIcon", "stIconInTitle_address"); //-apagar
                    _formHeaderAux.Add("thisScreenIs", "aux"); // parâmetro que determina se essa é a tala principal ou auxiliar
                    _formHeaderAux.Add("idInHeader", "idInHeader_address"); // id in header 
                    _formHeaderAux.Add("saveFormButtonId", "saveFormButton_address"); // id do botão save form
                    _formHeaderAux.Add("resetFormButtonId", "resetFormButton_address"); // id do botão reset form
                    _formHeaderAux.Add("resetFormButtonFunction", "resetForm_address()"); // função para reset form e desabilitar o botão save
                    _formHeaderAux.Add("operationInHeader", "operationInHeader_address"); // operation in header
                    _formHeaderAux.Add("divIdToshowHideDeleteButtonOnClick", "deleteRegisterConfirm_address"); // id da div escondida para deletar efetivamente o registro
                    _formHeaderAux.Add("addButton_aux", "advAddressMaintenance(0, 'a'," + __advertiserId.ToString() + ")");
                    _formHeaderAux.Add("deleteButtonOnClick", "sendAddressToDeleteInForm('" + _formHeaderAux["DivId"] + "', '#" + _formHeaderAux["idInHeader"] +"')"); // função e parâmetro usado no "onclick()" do botão de exclusão de registros
                                                              
                    _formHeaderAux.Add("FormTitle", (__operation == "a" ? "incluir" :
                                                    __operation == "e" ? "editar" :
                                                    __operation == "v" ? "visualizar" :
                                                    __operation == "d" ? "deletar" : "") + " registro"
                                                    );
                    ViewBag.FormHeaderAux = _formHeaderAux;
                    UfsApp _ufsApp = new UfsApp();
                    CitiesApp _citiesApp = new CitiesApp();
                    ViewBag.Ddl_States = new SelectList(_ufsApp.ListAll(), "UF", "Name", _obj.Uf);
                    ViewBag.Ddl_Cities = new SelectList(_citiesApp.ListAll(), "Id", "Name", _obj.CityId);

                    //ViewBag.AddressId = _obj.Id;
                    ViewBag.Operation = __operation;

                    return PartialView(_obj);
                }
            }

            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _jsonAdressesMaintenanceFormSubmit(FormCollection dados, Advertiser_address __obj)
        {
            //int _addressId = Convert.ToInt16(dados["inputAddressId"].ToString());
            //int _advertiserId = Convert.ToInt16(dados["inputAdvertiserId"].ToString());
            //var _st = Convert.ToString(dados["St"]);

            __obj = _advertisers_adressesApp.Save(__obj);

            return Json(__obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult _jsonAdressesFormFill(int __addressId = 0, string __operation = "a")
        {
            if (!String.IsNullOrEmpty(__operation))
            {
                if (__operation == "a" || __operation == "e" || __operation == "d" || __operation == "v")
                {
                    Advertiser_address _obj = new Advertiser_address();

                    if (__operation != "a")
                    {
                        if (__addressId > 0)
                            _obj = _advertisers_adressesApp.SearchById(__addressId,"full"); //_context.Advertisers_adresses.FirstOrDefault(x => x.Id == __addressId);
                    }

                    ViewBag.AddressId = _obj.Id;

                    return Json(_obj, JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }

        [HttpPost]
        public JsonResult _jsonAdressesDelete(int __addressId)
        {
            bool _retorno = false;

            try
            {
                _advertisers_adressesApp.Delete(__addressId);
                _retorno = true;
            }
            catch (Exception e)
            {
                throw;
            }
            
            return Json(_retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult _adressesView(int __addressId, string __operation)
        {
            if (!String.IsNullOrEmpty(__operation))
            {
                Advertiser_address _obj = _context.Advertisers_adresses.FirstOrDefault(x => x.Id == __addressId);

                IDictionary<string, string> _formHeaderAux = new Dictionary<string, string>();
                _formHeaderAux.Add("St", _obj.St.ToString());
                _formHeaderAux.Add("Operation", __operation);
                _formHeaderAux.Add("Id", _obj.Id.ToString());
                _formHeaderAux.Add("Name", "Endereço");
                _formHeaderAux.Add("DivId", "adressesView");
                _formHeaderAux.Add("FormIdIcon", "stIconInTitle_address");
                _formHeaderAux.Add("idInHeader", "idInHeader_address"); // id in header 
                _formHeaderAux.Add("saveFormButtonId", "saveFormButton_address"); // id do botão save form
                _formHeaderAux.Add("thisScreenIs", "aux"); // parâmetro que determina se essa é a tala principal ou auxiliar
                _formHeaderAux.Add("divIdToshowHideDeleteButtonOnClick", "deleteRegisterConfirm_addressView"); // id da div escondida para deletar efetivamente o registro
                _formHeaderAux.Add("operationInHeader", "operationInHeader_address"); // operation in header
                _formHeaderAux.Add("addButton_aux", "advAddressMaintenance(0, 'a'," + _obj.AdvertiserId.ToString() + ")");
                _formHeaderAux.Add("deleteButtonOnClick", "sendAddressToDeleteInForm('" + _formHeaderAux["DivId"] + "', '#" + _formHeaderAux["idInHeader"] + "')"); // função e parâmetro usado no "onclick()" do botão de exclusão de registros
                _formHeaderAux.Add("FormTitle",     (__operation == "v" ? "visualizar" :
                                                    __operation == "d" ? "deletar" : "") + " registro"
                                                    );
                ViewBag.FormHeaderAux = _formHeaderAux;

                ViewBag.Operation = __operation;

                return PartialView(_obj);              
            }

            return null;
        }
    }
}