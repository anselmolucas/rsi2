using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class UsersApp
    {
        Context _context = new Context();
        Functions _functions = new Functions();

        public User Save(User __obj)
        {
            __obj = Fix(__obj);

            if (__obj.Id == 0) // se não tem id é pq é um registro novo
            {
                __obj = Add(__obj);
            }

            else
                __obj = Update(__obj);

            return __obj;
        }

        public User Add(User __obj)
        {
            using (var _context = new Context())
            {
                _context.Users.Add(__obj);
                _context.SaveChanges();
            }
            return __obj;
        }

        /// <summary>
        /// realiza ajustes nos campos do registro, inclusive eliminando os "nulls", se __obj.Id == 0 é inclusão (Add)
        /// </summary>
        /// <param name="__obj"></param>
        public User Fix(User __obj)
        {            
            //__obj.Id
            __obj.UserEmail                 = __obj.UserEmail ?? "";
            __obj.UserFirstName             = __obj.UserFirstName ?? "";
            __obj.UserLastName              = __obj.UserLastName ?? "";
            //__obj.UserPower               = __obj.UserEmail ?? "";
            //__obj.Department              = __obj.UserEmail ?? "";
            //__obj.UserPassword              = __obj.UserPassword ?? "";
            //__obj.UserPasswordEncryptedMD5  = !String.IsNullOrEmpty(__obj.UserPassword) ? _functions.__getMD5Hash(__obj.UserPassword) : __obj.UserPasswordEncryptedMD5;
            __obj.FileName                  = __obj.FileName ?? "";

            __obj.AddUserId                 = 1;
            __obj.UpdateUserId              = 1;
            __obj.AddDate                   = __obj.Id > 0 ? __obj.AddDate : System.DateTime.Now;
            __obj.UpdateDate                = System.DateTime.Now;
            //__obj.St                      = status.nS;

            return __obj;
        }

        public User Update(User __objUpdate)
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                User _objOriginal = _context.Users.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);

                    _context.SaveChanges();
                }
            }

            return __objUpdate;
        }

        public IEnumerable<User> List(string __key = "", string __field = "")
        {
            using (var _context = new Context())
            {
                IEnumerable<User> _retorno = null;

                if (String.IsNullOrEmpty(__key) && String.IsNullOrEmpty(__field))
                    _retorno = _context.Users.ToList();

                return _retorno;
            }
        }

        //public User Search(string __key, string __field = "id", string __type = "string")
        //{
        //    using (var _context = new Context())
        //    {
        //        User _retorno = null;

        //        if (!String.IsNullOrEmpty(__key) && !String.IsNullOrEmpty(__field))
        //        {
        //            string _expression = "";
        //            _expression = "x=> x." + __field + " == " + (__type == "int" ? "Convert.ToInt16(" + __key + ")" : __key);
        //            _retorno = _context.Users.Where(Convert.ToBoolean(_expression)).FirstOrDefault();
        //            _retorno = _context.Users.Where(x=> x.(string)__field == __key).FirstOrDefault();
        //        }

        //        return _retorno;
        //    }
        //}

        public User Search(int __id)
        {
            using (var _context = new Context())
            {
                User _retorno = null;

                    _retorno = _context.Users.Where(x => x.Id == __id).FirstOrDefault();
            
                return _retorno;
            }
        }

        public User ValidLogin(Login _loginObj)
        {
            User _userObj;

            _userObj = _context.Users.FirstOrDefault(x => x.UserEmail == _loginObj.UserEmail);
            var _senha = _functions.__getMD5Hash(_loginObj.UserPassword);
            if (_userObj.UserPasswordEncryptedMD5 != _functions.__getMD5Hash(_loginObj.UserPassword))
                _userObj = null;

            return _userObj;
        }

        public void Delete(int __id)
        {
            using (var _context = new Context())
            {
                User _objToDelete = _context.Users.Where(x => x.Id == __id).FirstOrDefault(); //Search(__id.ToString());

                if (_objToDelete != null)
                {
                    try
                    {
                        _context.Users.Remove(_objToDelete);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ocorreu um erro ao tentar deletar o registro: " + ex.Message);
                    }
                    finally
                    {
                    }
                }
            }
        }

        public void SendNewPassword(User __userObj)
        {
            EmailBox _emailBoxObj = new EmailBox();

            #region messageText
            //para inserir imagens no email vide link:
            //http://pt.stackoverflow.com/questions/30463/colocar-imagem-local-no-body-ao-enviar-um-email
            //ou
            //https://israelaece.com/2005/10/16/embutindo-imagens-no-envio-de-emails/

            string _subject     = "RSI - BackEnd: aviso de novo usuário";
            string _link1       = String.Format("<html><body><p><a href=\"http://localhost:49458/backEnd/UserAccounts/ChangePassword?__user={0}\">***clique aqui para acessar o sistema e trocar a sua senha temporária... </a></body></html>", __userObj.UserEmail);
            string _link2       = "<html><body><p>caso você não consiga acessar o link para alterar a sua senha provisória, por gentileza acesse o site: <a href=\"http://www.rosanascottindica/backend/UserAccounts/ChangePassword/\">http://www.rosanascottindica/backend/UserAccounts/ChangePassword </a></p></body></html>";
            string _link3       = "<html><body><p>conheça o nosso site: <a href=\"http://www.rosanascott.com.br/\">rosanascottindica.com.br </a></body></html>";
            
            var _message        = "<h1><u>" + _subject + "</u></h1>";
                _message       += "<h4> envio de link para acesso ao sistema </h4>";
                _message        += String.Format("<h2> Prezado(a) {0},</h2>", __userObj.UserFirstName);
                _message        += "<br />";
                _message        += "<p>Benvinda ao <b><i>RSI - Rosana Scott Indica!!!</b></i></p>";
                _message        += "<p>Segue o link para acessar o sistema RSI e alterar a senha temporária:</p>";
                _message        += _link1;
                _message        += _link2;
                _message        += "<br />";
                _message        += "<p>senha temporária: ";
                //_message        += "<b>" + __userObj.UserPassword + "</b></p>";
                _message        += "<p>Obs.: Se você desconhece esse assunto, peço por gentileza, que entre em contato com o administrador do site RSI.<p>";
                _message        += "<br /><br />";         
                _message        += " <p> Atenciosamente,</p>";
                _message        += " <p><b>RSI - backEnd</b></p>";
                _message        += _link3;
            #endregion

            _emailBoxObj.Email_Sender = String.IsNullOrEmpty(_emailBoxObj.Email_Sender) ? "anselmolucas@gmail.com" : _emailBoxObj.Email_Sender;
            _emailBoxObj.Email_Sender_Name = String.IsNullOrEmpty(_emailBoxObj.Email_Sender_Name) ? "RSI - backEnd" : _emailBoxObj.Email_Sender_Name;
            _emailBoxObj.Email_To = String.IsNullOrEmpty(_emailBoxObj.Email_To) ? __userObj.UserEmail : _emailBoxObj.Email_To;
            _emailBoxObj.Email_To_Name = String.IsNullOrEmpty(_emailBoxObj.Email_To_Name) ? __userObj.UserLastName + ", " + __userObj.UserFirstName : _emailBoxObj.Email_To_Name;
            _emailBoxObj.Email_Subject = String.IsNullOrEmpty(_emailBoxObj.Email_Subject) ? _subject : _emailBoxObj.Email_Subject;
            _emailBoxObj.Email_Body = String.IsNullOrEmpty(_emailBoxObj.Email_Body) ? _message : _emailBoxObj.Email_Body;
            _emailBoxObj.Email_Priority = System.Net.Mail.MailPriority.Normal;

            bool _envio_Ok = _functions.SendMessages(_emailBoxObj);
        }        
    }
}
