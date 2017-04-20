using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    public class Login
    {      
        [Required(ErrorMessage = "*** o email é uma informação necessária!!!")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "informar o e-mail no formato correto!!!")]
        [DataType(DataType.Html)]
        [DisplayName("e-mail")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "a senha precisa ser preenchida!")]
        [StringLength(15, ErrorMessage = "a senha precisa ter entre 3 e 15 caracteres", MinimumLength = 3)]
        [DataType(DataType.Password)]        
        [DisplayName("senha")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "é necessário confirmar a senha")]
        [StringLength(15, ErrorMessage = "a senha precisa ter entre 3 e 15 caracteres", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Compare("UserPassword")]
        [DisplayName("redigitação da senha")]
        public string UserPasswordReType { get; set; }

        [Required(ErrorMessage = "a senha anterior precisa ser preenchida!")]
        [StringLength(15, ErrorMessage = "a senha precisa ter entre 3 e 15 caracteres", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [DisplayName("senha anterior")]
        public string UserOldPassword { get; set; }

        [DisplayName("mantenha-me conectado")]
        public bool LetMeConnected { get; set; }
    }
}
