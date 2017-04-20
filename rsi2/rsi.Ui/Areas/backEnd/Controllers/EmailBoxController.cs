/*
controller.....: EmailBox
system.........: rsi
descrição......: listar / encaminhar / responder / compor / deletar / imprimir mensagens
author.........: anselmolucas@gmail.com
date...........: 01/set/2016
status.........: 80% ok (falta opção print)
*/

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
    public class EmailBoxController : Controller
    {
        Context _context = new Context();
        EmailBoxApp _emailBoxApp = new EmailBoxApp();
        Functions _func = new Functions();

        public ActionResult Mailbox()
        {
            ViewBag.Title = "mailbox";
            ViewBag.PageTitle = "inbox";
            ViewBag.SubTitle = "caixa de mensagens";

            ViewBag.PreviousScreen = "home";
            ViewBag.PreviousScreenLink = "/backEnd/Admin/Index";
            ViewBag.CurrentScreen = "inbox";

            ViewBag.MessagesList = _context.EmailBoxes.Where(x => x.ReadingStatus == readingStatus.Unread).ToList();

            CrialistaESumariza();

            return View();
        }

        [HttpGet]
        public ActionResult View(int id, string o)
        {
            ViewBag.Title = "mailbox";
            ViewBag.PageTitle = "inbox";
            ViewBag.SubTitle = "ler mensagem";

            ViewBag.PreviousScreen = "inbox";
            ViewBag.PreviousScreenLink = "/EmailBox/Mailbox";
            ViewBag.CurrentScreen = "ler mensagem";

            var _messageObj = _context.EmailBoxes.FirstOrDefault(x => x.Id == id);
            ViewBag.PageTitle = o;

            if (_messageObj != null)
            {
                _messageObj = _emailBoxApp.UpdateStatusMessage(_messageObj, "read");
            }

            CrialistaESumariza();

            return View(_messageObj);
        }

        [HttpGet]
        public ActionResult List(string id)
        {
            var _messageList = _context.EmailBoxes.ToList();

            if (id == "inbox")
                _messageList = _messageList.Where(x => x.ReadingStatus == readingStatus.Unread).ToList();

            else if (id == "RSI")
                _messageList = _messageList.Where(x => x.Receiver == receiver.toSiteOwner && (x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread)).ToList();

            else if (id == "anunciantes")
                _messageList = _messageList.Where(x => x.Receiver == receiver.toAdvertiser && (x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread)).ToList();

            else if (id == "orçamento")
                _messageList = _messageList.Where(x => x.Receiver == receiver.toAdvertiserBudgetRequest && (x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread)).ToList();

            else if (id == "arquivo")
                _messageList = _messageList.Where(x => x.ReadingStatus == readingStatus.archived).ToList();

            else if (id == "rascunho")
                _messageList = _messageList.Where(x => x.ReadingStatus == readingStatus.draft).ToList();

            else if (id == "enviadas")
                _messageList = _messageList.Where(x => x.ReadingStatus == readingStatus.sent || x.ReadingStatus == readingStatus.reply || x.ReadingStatus == readingStatus.forward || x.ReadingStatus == readingStatus.compose).ToList();

            else if (id == "lixeira")
                _messageList = _messageList.Where(x => x.ReadingStatus == readingStatus.trash).ToList();

            else
                return RedirectToAction("Mailbox");

            ViewBag.PageTitle = id;
            ViewBag.MessagesList = _messageList;
            CrialistaESumariza();

            return View();
        }

        public void CrialistaESumariza()
        {
            var _messagesFullList = _context.EmailBoxes.ToList();
            var _messagesList = _messagesFullList.Where(x => x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread).ToList();
            var _inbox = _messagesList.Where(x => x.ReadingStatus == readingStatus.Unread);
            var _messagesToSiteOwnerList = _messagesList.Where(x => x.Receiver == receiver.toSiteOwner);
            var _messagesToAdvertiserList = _messagesList.Where(x => x.Receiver == receiver.toAdvertiser);
            var _messagesToAdvertiserBudgetRequestList = _messagesList.Where(x => x.Receiver == receiver.toAdvertiserBudgetRequest);
            var _messagesArchivedList = _messagesFullList.Where(x => x.ReadingStatus == readingStatus.archived);
            var _messagesDraftList = _messagesFullList.Where(x => x.ReadingStatus == readingStatus.draft);
            var _messagesSentList = _messagesFullList.Where(x => x.ReadingStatus == readingStatus.sent || x.ReadingStatus == readingStatus.reply || x.ReadingStatus == readingStatus.forward || x.ReadingStatus == readingStatus.compose);
            var _messagesDeletedList = _messagesFullList.Where(x => x.ReadingStatus == readingStatus.trash);

            ViewBag.InboxList = _inbox;
            ViewBag.MessagesToSiteOwnerList = _messagesToSiteOwnerList;
            ViewBag.MessagesToAdvertiserList = _messagesToAdvertiserList;
            ViewBag.MessagesToAdvertiserBudgetRequestList = _messagesToAdvertiserBudgetRequestList;
            ViewBag.MessagesArchivedList = _messagesArchivedList;
            ViewBag.MessagesDraftList = _messagesDraftList;
            ViewBag.MessagesSentList = _messagesSentList;
            ViewBag.MessagesDeletedList = _messagesDeletedList;

            ViewBag.InboxListCount = _inbox.Count();
            ViewBag.MessagesToSiteOwnerListCount = _messagesToSiteOwnerList.Count();
            ViewBag.MessagesToSiteOwnerListCountNotRead = _messagesToSiteOwnerList.Where(x => x.ReadingStatus == readingStatus.Unread).Count();
            ViewBag.MessagesToAdvertiserListCount = _messagesToAdvertiserList.Count();
            ViewBag.MessagesToAdvertiserListCountNotRead = _messagesToAdvertiserList.Where(x => x.ReadingStatus == readingStatus.Unread).Count();
            ViewBag.MessagesToAdvertiserBudgetRequestListCount = _messagesToAdvertiserBudgetRequestList.Count();
            ViewBag.MessagesToAdvertiserBudgetRequestListCountNotRead = _messagesToAdvertiserBudgetRequestList.Where(x => x.ReadingStatus == readingStatus.Unread).Count();
            ViewBag.MessagesArchivedListCount = _messagesArchivedList.Count();
            ViewBag.MessagesSentListCount = _messagesSentList.Count();
            ViewBag.MessagesDraftListCount = _messagesDraftList.Count();
            ViewBag.MessagesDeletedListCount = _messagesDeletedList.Count();
        }

        [HttpGet]
        public ActionResult UpdateStatusMessage(int id, string s = "read")
        {
            var _messageObj = _context.EmailBoxes.FirstOrDefault(x => x.Id == id);
            EmailBoxApp _emailBoxApp = new EmailBoxApp();

            if (_messageObj != null)
                _messageObj = _emailBoxApp.UpdateStatusMessage(_messageObj, s);

            return RedirectToAction("Mailbox");
        }

        [HttpGet]
        public ActionResult ReplyForwardCompose(int id, string o)
        {
            ViewBag.Title = "mensagem";
            ViewBag.PageTitle = "mensagem (encaminhar)";
            ViewBag.SubTitle = "encaminhar";

            ViewBag.PreviousScreen = "inbox";
            ViewBag.PreviousScreenLink = "/EmailBox/Mailbox";
            ViewBag.CurrentScreen = "ler mensagem";

            EmailBox _messageObj;

            if (o == "compose")
            {
                var _message = "<h1><u> Título da mensagem (sugestão / modelo) </u></h1>";
                _message += "<h4> Sub - Título (sugestão / modelo) </h4>";
                _message += "<p> Mussum Ipsum, cacilds vidis litro abertis.Posuere libero varius.Nullam a nisl ut ante blandit hendrerit.Aenean sit amet nisi.Nullam volutpat risus nec leo commodo, ut interdum diam laoreet.Sed non consequat odio.Diuretics paradis num copo é motivis de denguis.Interagi no mé, cursus quis, vehicula ac nisi.</p>";
                _message += "<ul>";
                _message += "<li> item 1 </li>";
                _message += "<li> item 2 </li>";
                _message += "<li> item 3 </li>";
                _message += "</ul>";
                _message += " <p> Obrigado,</p>";
                _message += " <p> John Doe</p>";

                _messageObj = new rsi.Entities.EmailBox()
                {
                    Email_Body = _message
                };
            }
            else
            {
                _messageObj = _context.EmailBoxes.FirstOrDefault(x => x.Id == id);

                if (_messageObj == null)
                {
                    return RedirectToAction("Mailbox");
                }

                _messageObj.Email_Body = "<br /><br /><br />" +
                                    "<br />--------------------------------------------------------------------------------------<br />" +
                                    "*** mensagem original ***<br />" +
                                    "De: <b>" + _messageObj.Email_Sender_Name + "(" + _messageObj.Email_Sender + ")</b><br />" +
                                    "Enviada em: " + _messageObj.AddDate.ToLongDateString() + " - " + _messageObj.AddDate.ToShortTimeString() + "<br />" +
                                    "Para: <b>" + _messageObj.Email_To + "</b><br />" +
                                    "Assunto:<b>" + _messageObj.Email_Subject + "</b><br />" +
                                    "<p>" + _messageObj.Email_Body + "</p>" +
                                    "*** fim da mensagem original! ***" +
                                    "<br />--------------------------------------------------------------------------------------<br />";

            }

            ViewBag.Operation = o;
            _messageObj.Email_To = o == "compose" || o == "forward" ? "" : _messageObj.Email_Sender;
            ViewBag.Title = "mensagem";
            ViewBag.SubTitle = ViewBag.CurrentScreen = o == "compose" ? "criar nova" : o == "reply" ? "responder" : "encaminhar";
            _messageObj.Email_Subject = o == "compose" ? "" : "(" + ViewBag.SubTitle + ") " + _messageObj.Email_Subject;

            CrialistaESumariza();

            return View(_messageObj);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var _messageObj = _context.EmailBoxes.FirstOrDefault(x => x.Id == id);

            if (_messageObj != null)
            {
                _emailBoxApp.Delete(_messageObj);
            }

            return RedirectToAction("Mailbox");
        }

        [HttpGet]
        public ActionResult Print(int id)
        {
            var _messageObj = _context.EmailBoxes.FirstOrDefault(x => x.Id == id);

            if (_messageObj != null)
            {

            }

            return RedirectToAction("Mailbox");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Send(EmailBox __obj, FormCollection _formCollection)
        {
            string _operation = Convert.ToString(_formCollection["operation"]); // possibilidades: reply, forward ou compose
            string _action = Convert.ToString(_formCollection["action"]); // possibilidades: draft ou send
            string _id = Convert.ToString(_formCollection["Id2"]);
            bool _envio_Ok = false;

            __obj.Email_Sender = String.IsNullOrEmpty(__obj.Email_Sender) ? "anselmolucas@gmail.com" : __obj.Email_Sender;
            __obj.Email_Sender_Name = String.IsNullOrEmpty(__obj.Email_Sender_Name) ? "sender não informado" : __obj.Email_Sender_Name;
            __obj.Email_To = String.IsNullOrEmpty(__obj.Email_To) ? "destinatário não informado" : __obj.Email_To;
            __obj.Email_To_Name = String.IsNullOrEmpty(__obj.Email_To_Name) ? "destinatário não informado" : __obj.Email_To_Name;
            __obj.Email_Subject = String.IsNullOrEmpty(__obj.Email_Subject) ? "assunto não informado" : __obj.Email_Subject;
            __obj.Email_Body = String.IsNullOrEmpty(__obj.Email_Body) ? "corpo da mensagem não informado" : __obj.Email_Body;
            __obj.Email_Priority = System.Net.Mail.MailPriority.Normal;
            //reply, forward, compose
            __obj.ReadingStatus = _action == "draft" ? readingStatus.draft :
                                      _operation == "reply" && _action != "draft" ? readingStatus.reply :
                                      _operation == "forward" && _action != "draft" ? readingStatus.forward :
                                      _operation == "compose" && _action != "draft" ? readingStatus.compose : readingStatus.notSet;

            __obj.OriginalMessageId = __obj.Id;
            __obj.Id = 0;
            __obj.St = status.on;
            __obj.Client_Host = theSetup.email_client_Host;

            if (_action == "draft")
            {
                var _obj = _emailBoxApp.Save(__obj);
            }
            else if (_action == "send")
            {
                __obj.Receiver = receiver.toVisitor;

                var _obj = _emailBoxApp.Save(__obj);
                if (_obj != null)
                {
                    _envio_Ok = _func.SendMessages(__obj);
                }
                if (!_envio_Ok)
                {
                    _emailBoxApp.Delete(__obj);
                }
            }

            //todo: ativar jquery validate
            //todo: ativar consistência de campos via data annotations na classe EmailBox

            return RedirectToAction("Mailbox");
        }
    }
}