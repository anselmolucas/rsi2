using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Http;
using rsi.Entities;
using rsi.Entities.configurations;
//using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Configuration;

namespace rsi.Apps
{
    public class Functions //: INotifyPropertyChanged
    {
        private Context _context;

        //-----------------------------------------------------------------------------------------------------------\\
        // método: hashCode
        //-----------------------------------------------------------------------------------------------------------\\
        /// <summary>
        /// cria o hascode a partir de uma string
        /// </summary>
        ///<param name="_tamanho">tamanho da cadeia de caracteres a ser gerada, padão de 8 caracteres</param>
        ///<param name="_prefixo">string que conterá a cadeia de caracteres que será inserida no início do hashcode que será gerado (veja abaixo a lista com os possíveis prefixos)</param>
        ///<param name="_usar_letrasMin">estabelece se o hashcode a ser criado poderá ter letras as minúsculas do alfabeto</param>
        ///<param name="_usar_letrasMai">estabelece se o hashcode a ser criado poderá ter letras as maiúsculas do alfabeto</param>
        ///<param name="_usar_numeros">estabelece se o hashcode a ser criado poderá ter números</param>
        ///<param name="_usar_especiais">estabelece se o hashcode a ser criado poderá ter caracteres especiais</param>
        ///<param name="_sufixo">string "opcional" que conterá a cadeia de caracteres que será inserida no final do hashcode que será gerado</param>        
        /// <returns>_hash_code - prefixo + hashcode + sufixo </returns>
        /// <remarks>uso previsto:
        /// <para>a)  nomear arquivos (imagens, sons, vídeos, textos) - a regra para nomear "arquivos" é sufixo (vide prefixos abaixo) + hashcode gerado + extensão do arquivo</para>
        /// <para>b)  nomear ids (id_user, id_owner, id_place, id_curso, id_aula, id_slide) - a regra para nomear "ids" é sufixo (vide prefixos abaixo) + hashcode gerado</para>
        /// </remarks>
        /// <example>_id_produto = _functions.hashCode(12, "p@", true, false, true, false, "");</example>
        /// <remarks>                
        /// <list type="bullet">
        /// <listheader><term>*** prefixos ***</term><description>strings usados no início do hashcode</description></listheader>
        /// <item>
        /// <term>img - imagem</term><description>código a ser usado como id_imagem (.jpg,.png,.gif)</description>
        /// <term>vid - vídeos</term><description>código a ser usado como id_video  (.avi,.flv,.wmv,.mov,.rmvb,.mpeg,.mkv)</description>
        /// <term>aud - audios</term><description>código a ser usado como id_audio  (.mp3,.wma,.aax,.m4a,wav)</description>
        /// <term>doc - documentos</term><description>código a ser usado como id_doc    (.doc,.docx,.txt.,rtf,.pdf,.xml)</description>        
        /// </item>
        /// </list>
        /// </remarks>
        public static string __hashCode(int _tamanho = 8, string _prefixo = "", bool _usar_letrasMin = true, bool _usar_letrasMai = true, bool _usar_numeros = true, bool _usar_especiais = false, string _sufixo = "")
        {
            /***********************************************************************************************************
             ************** descrição: gerar um hashcode ***************************************************************
             *
             *              uso previsto:
             *              a)  nomear arquivos (imagens, sons, vídeos, textos) - a regra para nomear "arquivos" é sufixo 
             *                  (vide prefixos abaixo) + hashcode gerado + extensão do arquivo
             *              b)  nomear ids (id_user, id_owner, id_place, id_curso, id_aula, id_slide) - a regra para nomear 
             *                  "ids" é sufixo (vide prefixos abaixo) + hashcode gerado
             * 
             ***********************************************************************************************************/

            /*** parâmetros:
             *              _tamanho        -> tamanho da cadeia de caracteres a ser gerada, padão de 8 caracteres
             *              _prefixo        -> string que conterá a cadeia de caracteres que será inserida no início do 
             *                                 hashcode que será gerado (veja abaixo a lista com os possíveis prefixos)
             *              _usar_letrasMin -> estabelece se o hashcode a ser criado poderá ter letras as minúsculas do 
             *                                 alfabeto
             *              _usar_letrasMai -> estabelece se o hashcode a ser criado poderá ter letras as maiúsculas do 
             *                                 alfabeto
             *              _usar_numeros   -> estabelece se o hashcode a ser criado poderá ter números
             *              _usar_especiais -> estabelece se o hashcode a ser criado poderá ter caracteres especiais
             *              _sufixo         -> string "opcional" que conterá a cadeia de caracteres que será inserida no 
             *                                 final do hashcode que será gerado
             *                                 
             *** retorno:
             *              _hash_code      -> prefixo + hashcode + sufixo
             ***/

            /*** prefixos:
							img - imagem 		código a ser usado como id_imagem (.jpg,.png,.gif)
							vid - vídeos 		código a ser usado como id_video  (.avi,.flv,.wmv,.mov,.rmvb,.mpeg,.mkv)
							aud - audios 		código a ser usado como id_audio  (.mp3,.wma,.aax,.m4a,wav)
							doc - documentos 	código a ser usado como id_doc    (.doc,.docx,.txt.,rtf,.pdf,.xml)
							pla - places 		código a ser usado como id_place
							own - owners        código a ser usado como id_owner
             *              cur - curso         código a ser usado como id_curso
             *              aul - aula          código a ser usado como id_aula
             *              sli - slid          código a ser usado como id_slide
             *              
			***/

            string _letrasMin = "abcdefghijklmnopqrstuvwxyza";
            string _letrasMai = "ABCDEFGHIJKLMNOPQRSTUVWXYZA";
            string _numeros = "01234567892";
            string _especiais = "@@@###%%%---___~~~";
            string _hash_string = "";

            string _hash_code = "";
            string _has_code_aux = "";

            if (_usar_letrasMin)
            {
                _hash_string += _letrasMin;
            }

            if (_usar_letrasMai)
            {
                _hash_string += _letrasMai;
            }

            if (_usar_numeros)
            {
                _hash_string += _numeros;
            }

            if (_usar_especiais)
            {
                _hash_string += _especiais;
            }

            Random _random = new Random();

            for (int _i = 1; _i <= _tamanho; _i++)
            {
                int _tamanho_string = _hash_string.Length;
                int _random_num = _random.Next(_tamanho_string);

                /*if (_random_num > _tamanho_string || _random_num <1)
                {
                    _random_num = (_tamanho_string/3);
                }*/

                string _aux_hash = _hash_string.Substring(_random_num, 1);
                _hash_code += _aux_hash;
            }

            // após criar hashcode, pode-se acrescê-lo de prefixos e/ou sufixos, caso os parâmetros de cada um dos morfemas (afixos), sejam declarados.		
            _has_code_aux = _hash_code;
            _hash_code = _prefixo + _has_code_aux + _sufixo;

            return _hash_code.ToString();
        }

        //-----------------------------------------------------------------------------------------------------------\\
        // método: getMD5Hash
        //-----------------------------------------------------------------------------------------------------------\\
        /// <summary>
        /// gerar um código criptografado no padrão MD5
        /// <para>uso previsto:</para>
        /// <para>a)  armazenar senha de usuários</para>
        /// </summary>
        /// <param name="_input">string utilizada para a criação do hashcode</param>
        /// <returns>_sb             -> cadeia de caracteres já criptografada</returns>
        public string __getMD5Hash(string _input)
        {
            /***********************************************************************************************************
             ************** descrição: gerar um código criptografado no padrão MD5 *************************************
             *
             *              uso previsto:
             *              a)  armazenar senha de usuários
             * 
             ***********************************************************************************************************/

            /*** parâmetros:
             *              _string         -> variável que contém a senha a ser convertida
             *              
             *** retornos:  _sb             -> cadeia de caracteres já criptografada
             *              
             ***/

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(_input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder _sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                _sb.Append(hash[i].ToString("X2"));
            }
            return _sb.ToString();
        }

        //-----------------------------------------------------------------------------------------------------------\\
        // método: __dirCreate
        //-----------------------------------------------------------------------------------------------------------\\
        /// <summary>
        /// cria um diretório
        /// </summary>
        /// <param name="_diretorio">string com a path do diretório a ser criado </param>
        /// <returns>
        /// <para>true se conseguiu criar</para>
        /// <para>false se não conseguiu criar o diretório</para>
        /// </returns>
        public bool __dirCreate(string _diretorio)
        {
            bool _retorno;

            try
            {
                DirectoryInfo _dir = new DirectoryInfo(@_diretorio);
                _dir.Create();
                _retorno = true;
            }
            catch
            {
                _retorno = false;
            }

            return _retorno;
        }

        //-----------------------------------------------------------------------------------------------------------\\
        // método: __verifica_arquivo
        //-----------------------------------------------------------------------------------------------------------\\
        /// <summary>
        /// verifica se a extensão do arquivo está entre as extensões aceitas: .jpg .png .jpeg .gif .bmp, se o tamanho do mesmo está no intervalo permitido e se o fileupload tem um arquivo 
        /// </summary>
        /// <param name="_path">caminho do arquivo</param>
        /// <param name="_tem_imagem"></param>
        /// <param name="_tamanho_ok"></param>
        /// <param name="__extensoes_aceitas"></param>
        /// <returns></returns>
        public bool verifica_arquivo(string __path, string __arquivoUp, string __fileType)
        {
            bool _retorno = false;
            string _pathFull = __path + __arquivoUp;

            string _extensoes_aceitas = "";

            if (__fileType == "texto")
                _extensoes_aceitas = ".pdf .epub .txt .doc .docx";

            else if (__fileType == "image")
                _extensoes_aceitas = ".jpg .png .jpeg .gif .bmp";

            try
            {
                if (__path == null || __path == "")
                {
                    throw new System.ArgumentException("o caminho do arquivo precisa ser informado");
                }

                if (__arquivoUp == null || __arquivoUp == "")
                {
                    throw new System.ArgumentException("o nome do arquivo precisa ser informado / ou falha no fileupload!!!");
                }

                if (__arquivoUp == null || __arquivoUp == "")
                {
                    throw new System.Exception("falha no fileupload!!!");
                }

                //if (_produtosMetodo.verifica_arquivo(_path + FileUpload_imagem1.FileName, FileUpload_imagem1.HasFile, (FileUpload_imagem1.PostedFile.ContentLength < 2048000 ? true : false)))

            }
            catch
            {

            }
            finally
            {

            }

            return _retorno;
        }

        public bool verificaFileUpload(string __path, bool __tem_imagem, bool __tamanho_ok, string __extensoes_aceitas = ".jpg .png .jpeg .gif .bmp")
        {
            string _extensão_arquivo = Path.GetExtension(__path).ToLower();

            bool _retorno = false;

            try
            {
                if (__tem_imagem) // verifica se o fileupload tem um arquivo selecionado pelo usuário

                    if (__extensoes_aceitas.IndexOf(_extensão_arquivo) != -1)// testar se o arquivo esta entre os permitidos, por exemplo: ".jpg .png .jpeg .gif .bmp"                    

                        if (__tamanho_ok) // verifica se o arquivo está dentro do tamanho máximo permitido                        
                            _retorno = true;
                        else throw new System.Exception("o tamanho máximo do arquivo para upload é 2048000bytes (2 gigabytes0!!!");

                    else throw new System.Exception("as extensões aceitas para o upload são: " + __extensoes_aceitas);

                else throw new System.ArgumentException("o nome do arquivo precisa ser informado / ou falha no fileupload!!!");

            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro no upload do arquivo: " + ex.Message);
            }
            finally
            {
            }
            return _retorno;
        }

        public bool saveFileUpload(string __arquivoToSave)
        {
            bool _retorno = false;
            try
            {
                ///FileUpload_logo.SaveAs(MapPath(_path + FileUpload_logo.FileName));
            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro no upload do arquivo: " + ex.Message);
            }
            finally
            {
            }

            return _retorno;
        }

        // ---------------- novas funções --------------------\\
        /// <summary>
        /// recebe o arquivo "<input>" de um controller, salva o mesmo e atualiza a respectiva tabela. Para tanto invoca os métodos "UpdateFile" e "FileExtensionVerify"
        /// para usar o "HttpPostedFileBase" é necessário ter a referencia ao System.Web
        /// </summary>
        /// <param name="__file"></param>
        /// <param name="__id"></param>
        /// <param name="__fileType"></param>
        /// <param name="__dataTable"></param>
        /// <returns></returns>
        public static string FileSave(HttpPostedFileBase __file, string __fileName, string __fileUrl, string __fileType, string _pathTemp = "")
        {
            string _mediaFileName = "";
            _pathTemp = String.IsNullOrEmpty(_pathTemp) ? thePaths.fullPathRSI : _pathTemp;
            //_pathTemp = "A:/_cloudDrives/Dropbox/developer/projects/rsi/rsi.Ui/content/subCategories/";
            
            //string _path              = _fileType == "image" ? Paths.PathProductImages : Paths.PathBooksCollection;
            // ativar a linha acima e desativar as 3 linhas abaixo quando o site estiver no provedor
            //string _pathTemp = "A:/cloudDrivers/Dropbox/developer/projects/cSharp/eShopping/eShopping.admin/Content/";
            string _path = _pathTemp;

            string _fileExtension = FileExtensionVerify(__file, __fileType);
            string _dirPath = System.Web.HttpContext.Current.Server.MapPath("~");// + "/content/categories" + __fileName + _fileExtension;

            if (__file != null && __file.ContentLength > 0)
            {
                if (!String.IsNullOrEmpty(_fileExtension))
                {
                    try
                    {
                        __file.SaveAs(_path + __fileUrl + __fileName + _fileExtension); // salva o arquivo no servidor 
                        //__file.SaveAs(_dirPath + __fileName + _fileExtension); // salva o arquivo no servidor 
                        _mediaFileName = __fileName + _fileExtension;
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                else throw new System.Exception(" essa não é uma extensão de arquivo aceita para arquivos " + __fileType + "s!!!");
            }

            return _mediaFileName;
        }

        /// <summary>
        /// verifica se o arquivo enviado via "<input>", recebido pelo método "FileSave" do controller, tem a extensão aceita
        /// </summary>
        /// <param name="__file"></param>
        /// <param name="__fileType"></param>
        /// <returns></returns>
        private static string FileExtensionVerify(HttpPostedFileBase __file, string __fileType)
        {
            string _extensoes_aceitas = "";
            string _fileExtension = "";

            if (__fileType == "text")
                _extensoes_aceitas = ".txt .doc .docx";

            else if (__fileType == "pdf")
                _extensoes_aceitas = ".pdf";

            else if (__fileType == "epub")
                _extensoes_aceitas = ".epub";

            else if (__fileType == "image")
                _extensoes_aceitas = ".jpg .png .jpeg .gif .bmp";

            _fileExtension = System.IO.Path.GetExtension(__file.FileName).ToLower();  // obter a extensão do arquivo, por exemplo .gif

            if (_extensoes_aceitas.IndexOf(_fileExtension) < 0)
                _fileExtension = "";

            return _fileExtension;
        }

        public bool SendMessages(EmailBox __messageObj)
        {
            /* fonte:
             * http://codigosimples.net/2014/02/11/como-enviar-e-mails-utilizando-c-de-forma-simples/
            */
            bool _retorno = false;

            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //client.Host = theSetup.email_client_Host;// "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Credentials = new System.Net.NetworkCredential(theSetup.email_client_Credentials, theSetup.email_client_Credentials_password);//new System.Net.NetworkCredential("anselmolucas@gmail.com", "Shyv@1966");
            //MailMessage mail = new MailMessage();
            //mail.Sender = new System.Net.Mail.MailAddress(sender.EmailSender, theSetup.email_senderName);
            //mail.From = new MailAddress(sender.Email, sender.Name);
            //mail.To.Add(new MailAddress(sender.EmailTo, sender.EmailTo));

            //if(!String.IsNullOrEmpty(sender.EmailTo2))
            //    mail.To.Add(new MailAddress(sender.EmailTo2, sender.EmailTo2));

            //if (!String.IsNullOrEmpty(sender.EmailToCc))
            //    mail.To.Add(new MailAddress(sender.EmailToCc, sender.EmailToCc));

            //mail.Subject = sender.Subject;
            //mail.Body = sender.Message;
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.Normal;

            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Credentials = new System.Net.NetworkCredential("anselmo.lucas@hotmail.com", "Shyv@1966");//new System.Net.NetworkCredential("anselmolucas@gmail.com", "Shyv@1966");
            //MailMessage mail = new MailMessage();
            //mail.Sender = new System.Net.Mail.MailAddress("anselmolucas@gmail.com", "Enviador");
            //mail.From = new MailAddress("anselmolucas@gmail.com", "Enviador");
            //mail.To.Add(new MailAddress("anselmo.lucas@hotmail.com","recebedor"));

            //if (!String.IsNullOrEmpty(sender.EmailTo2))
            //    mail.To.Add(new MailAddress(sender.EmailTo2, sender.EmailTo2));

            //if (!String.IsNullOrEmpty(sender.EmailToCc))
            //    mail.To.Add(new MailAddress(sender.EmailToCc, sender.EmailToCc));

            //mail.Subject = "assunto";
            //mail.Body = " Mensagem do site:<br/> Nome:  ";
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.Normal;


            //SmtpClient client = new SmtpClient("smtp.gmail.com");
            ////If you need to authenticate
            //client.Credentials = new NetworkCredential("anselmolucas@gmail.com", "Shyv@1966");

            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("anselmolucas@gmail.com", "Enviador");
            //mailMessage.To.Add("anselmo.lucas@hotmail.com");
            //mailMessage.Subject = "Hello There";
            //mailMessage.Body = "Hello my friend!";

            //try
            //{
            //    //client.Send(mail);
            //    client.Send(mailMessage);
            //    _retorno = true;
            //}
            //catch (System.Exception erro)
            //{
            //    //trata erro
            //}
            //finally
            //{
            //    //mail = null;
            //}
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Credentials = new System.Net.NetworkCredential("anselmolucas@gmail.com", "Shyv@1966");
            //MailMessage mail = new MailMessage();
            //mail.Sender = new System.Net.Mail.MailAddress("anselmo@softbox.com.br", "mail_sender");
            //mail.From = new MailAddress("anselmolucas@gmail.com", "mail_from");
            //mail.To.Add(new MailAddress("anselmo.lucas@hotmail.com", "Mail_to"));
            //mail.Subject = "**** Contato via email do site ************";
            //mail.Body = " ***** Mensagem do site:<br/> Nome:  " + "<br/> Email : " +  " <br/> Mensagem : " ;
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.Normal;
            //try
            //{
            //    client.Send(mail);
            //    _retorno = true;
            //}
            //catch (System.Exception erro)
            //{
            //    //trata erro
            //}
            //finally
            //{
            //    mail = null;
            //}

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = theSetup.email_client_Host;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(theSetup.email_client_Credentials, theSetup.email_client_Credentials_password);//new System.Net.NetworkCredential("anselmolucas@gmail.com", "Shyv@1966");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress(__messageObj.Email_Sender, __messageObj.Email_Sender_Name);
            mail.From = new MailAddress(__messageObj.Email_Sender, __messageObj.Email_Sender_Name);
            mail.To.Add(new MailAddress(__messageObj.Email_To, __messageObj.Email_To_Name));

            if (!String.IsNullOrEmpty(__messageObj.Email_To2))
                mail.To.Add(new MailAddress(__messageObj.Email_To2, ""));

            if (!String.IsNullOrEmpty(__messageObj.Email_Cc))
                mail.CC.Add(new MailAddress(__messageObj.Email_Cc, ""));

            if (!String.IsNullOrEmpty(__messageObj.Email_Bcc))
                mail.Bcc.Add(new MailAddress(__messageObj.Email_Bcc, ""));

            mail.Subject = __messageObj.Email_Subject;
            mail.Body = __messageObj.Email_Body;
            mail.IsBodyHtml = true;

            if (__messageObj.Email_Priority != 0)
                mail.Priority = __messageObj.Email_Priority;

            try
            {
                client.Send(mail);
                _retorno = true;
            }
            catch (System.Exception erro)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }


            return _retorno;
        }

        public void TruncateTable(string __table)
        {
            using (var context = new Context())
            {
                // cria comando
                var deleteCommand = context.Database.Connection.CreateCommand();
                deleteCommand.CommandText = "DELETE FROM " + __table;

                // executa comando
                context.Database.Connection.Open();
                deleteCommand.ExecuteNonQuery();
                context.Database.Connection.Close();

                deleteCommand.CommandText = "ALTER TABLE " + __table + " AUTO_INCREMENT = 1";

                // executa comando
                context.Database.Connection.Open();
                deleteCommand.ExecuteNonQuery();
                context.Database.Connection.Close();
            }
        }

        /// <summary>
        /// apaga todos os registros que se enquadrem aos parametros enviados
        /// </summary>
        /// <param name="__key">conteúdo a ser considerado para exclusão de registros</param>
        /// <param name="__field">campo da tabela</param>
        /// <param name="__table">nome da tabela</param>
        public void __deleteRegisters(string __key, string __field, string __table)
        {
            using (var _context = new Context())
            {
                // cria comando
                var deleteCommand = _context.Database.Connection.CreateCommand();
                //DELETE FROM `rsisgbd`.`vitrinelists` WHERE `vitrinelists`.`VitrineId` = 3;
                string mysqlCommand = String.Format("DELETE FROM `rsisgbd`.`{0}` WHERE `{1}` = {2};", __table, __field, __key); //"DELETE FROM " + __table + " WHERE " + __field + "=" + __key + ";";
                deleteCommand.CommandText = mysqlCommand;

                // executa comando
                _context.Database.Connection.Open();
                deleteCommand.ExecuteNonQuery();
                _context.Database.Connection.Close();
            }
        }

        /// <summary>
        /// função que ajusta texto para um determinado tamanho,k além de analisá-lo se é nulo
        /// </summary>
        /// <param name="__text">texto que será analisado e ajustado</param>
        /// <param name="__maximumSize">tamanho máximo que o texto poderá ter</param>
        /// <param name="__additionalCharacters">caso se deseje, é possível adicionar caracteres, por exemplo "...", 
        /// caso o texto tenhha um tamanho maior que o desejado, para evitar a inserção do "__additionalCharacters", enviar esse parâmetro em branco ("")</param>
        /// <returns>texto analisado e ajustado, se texto enviado inicialmente for nulo, a função retornará ""</returns>
        public static string __maximumSizeOfTheText(string __text, int __maximumSize, string __additionalCharacters = "...")
        {            
            __text = !String.IsNullOrEmpty(__text) ?
                            __text.Length > __maximumSize ? 
                            __text.Substring(0, (__maximumSize - __additionalCharacters.Length)) + __additionalCharacters :
                            __text : ""; 

            return __text;
        }

        /// <summary>
        /// devolve o mês anterior ao mês corrente
        /// </summary>
        /// <returns></returns>
        public static DateTime __lastMonth()
        {           
            // pega o mês anterior...
            var _lastMonth = System.DateTime.Now.AddMonths(-1);
            // pega o ultimo dia do mês...
            _lastMonth = new DateTime(_lastMonth.Year, _lastMonth.Month, DateTime.DaysInMonth(_lastMonth.Year, _lastMonth.Month));
            // pega o ano anterior...
            _lastMonth = _lastMonth.AddYears(-1);

            return _lastMonth;
        }

        // fonte:
        // http://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// /// cria uma nova imagem redimensionada pelos paramentros "__maxWidth" e "__maxHeight"
        /// fonte: http://www.dotnetbull.com/2013/12/image-resizing-in-aspnet-c-dynamically.html
        /// </summary>
        /// <param name="__maxWidth">largura máxima</param>
        /// <param name="__maxHeight">altura máxima</param>
        /// <param name="__originalImageFullPath">nome do arquivo original (incluindo o diretório e a extesão do arquivo)</param>
        /// <param name="__newImageName">nome para salvar a nova imagem redimensionada</param>
        /// <param name="__resizedImagePath">diretório para salvar a nova imagem (se branco, salva no diretório da imagem original)</param>
        /// <param name="__proportionalImageAdjustment">"true" para ajustar a imagem proporcionamente e "false" para ajustar com as medidas passadas como parâmentro</param>
        /// <returns>retorna uma string com o nome da imagem redimensionada (full path + nome do arquivo de image + extensão do arquivo)</returns>
        public static string __imageResize(int __maxWidth, int __maxHeight, string __originalImageFullPath, string __newImageName, string __resizedImagePath = "", bool __proportionalImageAdjustment = false)
        {
            var image = System.Drawing.Image.FromFile(__originalImageFullPath);

            //  begin: ajuste proporcional da imagem
            var ratioX = (double)__maxWidth / image.Width;
            var ratioY = (double)__maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = __proportionalImageAdjustment ? (int)(image.Width * ratio) : __maxWidth;
            var newHeight = __proportionalImageAdjustment ? (int)(image.Height * ratio) : __maxHeight;
            //  end: ajuste proporcional da imagem

            var newImage = new Bitmap(newWidth, newHeight);
            __resizedImagePath = string.IsNullOrEmpty(__resizedImagePath) ? Path.GetDirectoryName(__originalImageFullPath) : __resizedImagePath;

            Graphics thumbGraph = Graphics.FromImage(newImage);

            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            thumbGraph.DrawImage(image, 0, 0, newWidth, newHeight);
            image.Dispose();

            string fileRelativePath = __resizedImagePath + "\\" + __newImageName + Path.GetExtension(__originalImageFullPath);

            try
            {
                newImage.Save(fileRelativePath, newImage.RawFormat);
                //newImage.Save(fileRelativePath, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return __newImageName + Path.GetExtension(__originalImageFullPath);
        }

        /// <summary>
        /// preencher o campo img com o nome do arquivo ou com o icone noImage
        /// </summary>
        /// <param name="__iconFileName">campo imagem da tabela "tab"</param>
        /// <param name="__tab">tabela relacionada</param>
        /// <returns></returns>
        public static string __displayIconFileName(string __iconFileName, string __tab)
        {
            string _img = "";

            if (__iconFileName != null)
            {
                if (!string.IsNullOrEmpty(__iconFileName.Trim()))
                {
                    if (__tab == "Categories")
                        _img = thePaths.categoriesImages;
                    else if (__tab == "SubCategories")
                        _img = thePaths.subCategoriesImages;
                    else if (__tab == "Displays")
                        _img = thePaths.displaysImages;
                    else if (__tab == "AdMedias")
                        _img = thePaths.advertisingsImages;
                    else if (__tab == "Advertisers")
                        _img = thePaths.advertisersImages;
                    else if (__tab == "Medias")
                        _img = thePaths.advertisersImages;
                    else if (__tab == "Users")
                        _img = thePaths.usersImages; 
                    else if (__tab == "DirectMenu")
                        _img = thePaths.displaysImages;

                    _img += __iconFileName;
                }
                else
                    _img = theSetup.noImage_path;
            }
            else
            {
                _img = theSetup.noImage_path;
            }

            return _img;
        }

        public static string __displayDateinFormat_ddmmmAA(DateTime __data)
        {
            string _day = String.Format("{0:dd}", __data);
            string _month = String.Format("{0:MMM}", __data);
            string _year = String.Format("{0:yy}", __data);
            string _date = _day + "-" + _month + "-" + _year;

            return _date;
        }

        public static string __displayDateinFormat_ddmmm(DateTime __data)
        {
            string _day = String.Format("{0:dd}", __data);
            string _month = String.Format("{0:MMM}", __data);            
            string _date = _day + "-" + _month;

            return _date;
        }

        /// <summary>
        /// Upload de arquivos
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="url"></param>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        public static void SendFilesByFtpToTheServer2(string arquivo, string url, string usuario, string senha)
        {
            try
            {
                FileInfo arquivoInfo = new FileInfo(arquivo);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(usuario, senha);
                request.UseBinary = true;
                request.ContentLength = arquivoInfo.Length;
                using (FileStream fs = arquivoInfo.OpenRead())
                {
                    byte[] buffer = new byte[2048];
                    int bytesSent = 0;
                    int bytes = 0;
                    using (Stream stream = request.GetRequestStream())
                    {
                        while (bytesSent < arquivoInfo.Length)
                        {
                            bytes = fs.Read(buffer, 0, buffer.Length);
                            stream.Write(buffer, 0, bytes);
                            bytesSent += bytes;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void __sendFilesByFtpToTheServer(HttpPostedFileBase file, string dirUrl= "t5", string fileNameWithExt="testeFTP.png")
        {
            //fonte: http://vishalsen.blogspot.com.br/2016/11/ftp-file-upload-in-4-step-ftp-file.html
            try
            {
                //string ftpServerIP = "186.233.88.166";
                //string ftpUserID = "neobugg";
                //string ftpPassword = "Enterprise@1";

                string ftpServerIP = "186.233.88.166";
                string ftpUserID = "rsi2";
                string ftpPassword = "enterprise";
                string ftpURI = "ftp.rsi.comercial.ws/content/categories";

                //string ftpServerIP = ConfigurationManager.AppSettings["ftpIP"];
                //string ftpUserID = ConfigurationManager.AppSettings["ftpUser"];
                //string ftpPassword = ConfigurationManager.AppSettings["ftpPass"];
                //string ftpURI = ConfigurationManager.AppSettings["ftpURI"];
                //Create Directory first Then
                __makeFTPDir(ftpURI, ftpUserID, ftpPassword, dirUrl);


                // Create an empty instance of the NetworkCredential class.
                NetworkCredential myCredentials = new NetworkCredential("", "", "");
                myCredentials.Domain = ftpURI;
                myCredentials.UserName = ftpUserID;
                myCredentials.Password = ftpPassword;

                // Create a WebRequest with the specified URL. 
                WebRequest myWebRequest = WebRequest.Create("http://dea0f0e8.iphotel.info/content/categories/");
                myWebRequest.Credentials = myCredentials;

                //string filename = "ftp://" + ftpServerIP + "//" + dirUrl + "//" + fileNameWithExt;
                string filename = "ftp://" + ftpURI + "//" + dirUrl + "//" + fileNameWithExt;
                FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(filename);
                ftpReq.UseBinary = true;
                ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
                ftpReq.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                //ftpReq.Credentials = myCredentials;// new NetworkCredential(ftpUserID, ftpPassword);
                byte[] fileData = null;
                using (BinaryReader b = new BinaryReader(file.InputStream))
                {
                    fileData = b.ReadBytes(file.ContentLength);
                }
                ftpReq.ContentLength = fileData.Length;
                using (Stream reqStream = ftpReq.GetRequestStream())
                {
                    reqStream.Write(fileData, 0, fileData.Length);
                }
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void __makeFTPDir(string ftpAddress, string login, string password, string pathToCreate)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;
            string[] subDirs = pathToCreate.Split('/');
            string currentDir = string.Format("ftp://{0}", ftpAddress);
            foreach (string subDir in subDirs)
            {
                try
                {
                    currentDir = currentDir + "/" + subDir;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(login, password);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                    ftpStream.Close();
                    response.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
