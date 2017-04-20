using rsi.Apps;
using rsi.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class imagesController : Controller
    {
        Context _context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult imagem(HttpPostedFileBase __file)
        {
            if (__file != null)
            {
                ImageMedia _imagem = new ImageMedia();
                _imagem.Imagem = new byte[__file.ContentLength];
                _imagem.ImagemMimeType = __file.ContentType;
                __file.InputStream.Read(_imagem.Imagem, 0, __file.ContentLength);
                
                // toDo: redimensionar a imagem
                WebImage webimg = new WebImage(__file.InputStream);
                webimg.Resize(100, 100);

                return RedirectToAction("Exibir", new { _imagem.Id });
            }

            return View();
        }
    

        [HttpGet]
        public FileContentResult ObterImagem(int id)
        {
            var _obj = _context.ImageMedias.Find(id);
            if (_obj != null)
            {
                System.Web.Mvc.FileContentResult _file = File(_obj.Imagem, _obj.ImagemMimeType);

                return _file;
            }
            return null;
        }

        public PartialViewResult _list()
        {
            var _list = _context.ImageMedias.ToList();

            return PartialView(_list);
        }
    }
}