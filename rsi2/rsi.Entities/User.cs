using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace rsi.Entities
{
    public class User : Auxiliar
    {
        public int Id { get; set; }

        //[RegularExpression(@"b[A-Z0-9._%-]+@[A-Z0-9.-]+.[A-Z]{2,4}b", ErrorMessage = "e-mail em formato inválido.")]
        [EmailAddress(ErrorMessage = "e-mail em formato inválido.")]
        [Required(ErrorMessage = "*** [e-mail] é uma informação necessária!!!")]
        [DisplayName("e-mail")]
        public string UserEmail { get; set; }

        [StringLength(20, ErrorMessage = "o nome do usuário precisa ter entre 2 e 20 caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "*** [nome] é uma informação necessária!!!")]
        [DisplayName("nome")]
        public string UserFirstName { get; set; }

        [StringLength(1000, ErrorMessage = "o sobrenome do usuário precisa ter entre 3 e 30 caracteres (mas não é de preenchimento obrigatório)", MinimumLength = 5)]       
        [DisplayName("sobrenome")]
        public string UserLastName { get; set; }

        /// <summary>
        /// tipos possíveis de usuários
        /// </summary>
        [Required(ErrorMessage = "*** [power] é uma informação necessária!!!")]
        [DisplayName("power")]
        public userPower UserPower { get; set; }

        /// <summary>
        /// se o userType for backEnd, é necessário saber o departamento
        /// </summary>
        [Required(ErrorMessage = "*** [departamento] é uma informação necessária!!!")]
        [DisplayName("departamento")]
        public department Department { get; set; }

        //[Required(ErrorMessage = "*** [senha] é uma informação necessária!!!")]
        //[StringLength(20, ErrorMessage = "a senha precisa ter entre 2 e 20 caracteres", MinimumLength = 2)]
        //[DataType(DataType.Password)]
        //[DisplayName("senha")]
        //public string UserPassword { get; set; }

        public string UserPasswordEncryptedMD5 { get; set; }
        public string FileName { get; set; }

        //[NotMapped]
        //[DataType(DataType.Password)]
        //[Compare("UserPassword", ErrorMessage = "a confirmação da senha não confere")]
        //[DisplayName("confirmação da senha")]
        //public string UserPasswordReType { get; set; }

        //[NotMapped]
        //[Required(ErrorMessage = "*** [nova senha] é uma informação necessária!!!")]
        //[StringLength(20, ErrorMessage = "a senha precisa ter entre 2 e 20 caracteres", MinimumLength = 2)]
        //[DataType(DataType.Password)]
        //[DisplayName("nova_senha")]
        //public string UserPasswordNew { get; set; }

        //[NotMapped]
        //[DataType(DataType.Password)]
        //[Compare("UserPasswordNew", ErrorMessage = "a confirmação da senha não confere")]
        //[DisplayName("confirmação da senha")]
        //public string UserPasswordNewReType { get; set; }

        //[NotMapped]
        //[DataType(DataType.Password)]
        //[Compare("UserEmail", ErrorMessage = "a confirmação do mail não confere")]
        //[DisplayName("confirmação do mail")]
        //public string UserEmailReType { get; set; }
    }
   
    public enum userPower
    {
        notSet, user1, managerSite, auditing, fullAdmin
    }

    public enum department
    {
        notSet, comercial, mkt, sac, administrativo, financeiro, suporte, direção
    }   
}