using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class EmailBoxApp
    {
        Context _context = new Context();

        public EmailBox Save(EmailBox __obj)
        {
            if (__obj.Id == 0) // se não tem id é pq é um registro novo
            {
                __obj = Add(__obj);
            }

            else
                __obj = Update(__obj);

            return __obj;
        }

        public EmailBox Add(EmailBox __obj)
        {
            using (var _context = new Context())
            {
                __obj.UpdateDate = System.DateTime.Now;
                __obj.AddDate = System.DateTime.Now;

                _context.EmailBoxes.Add(__obj);
                _context.SaveChanges();
            }
            return __obj;
        }

        public EmailBox Update(EmailBox __objUpdate)
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                EmailBox _objOriginal = _context.EmailBoxes.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    __objUpdate.UpdateDate = System.DateTime.Now;
                    __objUpdate.ReadingStatus = readingStatus.read;
                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);

                    _context.SaveChanges();
                }

            }

            return __objUpdate;
        }

        /// <summary>
        /// marcar uma mensagem como lida ou não lida
        /// </summary>
        /// <param name="__objUpdate"></param>
        /// <param name="_status">valors possíveis "read" and "unread"</param>
        /// <returns></returns>
        public EmailBox UpdateStatusMessage(EmailBox __objUpdate, string __status = "read")
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                EmailBox _objOriginal = _context.EmailBoxes.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    __objUpdate.UpdateDate = System.DateTime.Today;
                    __objUpdate.ReadingStatus = __status == "read" ? readingStatus.read :
                                                __status == "archived" ? readingStatus.archived :
                                                __status == "trash" ? readingStatus.trash :
                                                __status == "draft" ? readingStatus.draft :
                                                __status == "reply" ? readingStatus.reply :
                                                __status == "forward" ? readingStatus.forward :
                                                __status == "compose" ? readingStatus.compose :
                                                __status == "Unread" ? readingStatus.Unread : __objUpdate.ReadingStatus;

                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);

                    _context.SaveChanges();
                }
            }

            return __objUpdate;
        }

        public void Delete(EmailBox __obj)
        {
            using (var _context = new Context())
            {
                EmailBox _objToDelete = _context.EmailBoxes.Find(__obj.Id);

                if (_objToDelete != null)
                {
                    _context.EmailBoxes.Remove(_objToDelete);

                    _context.SaveChanges();
                }

            }
        }
    }
}
