using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rsi.Entities
{
    /// <summary>
    /// relacionamento n:n entre anunciantes e subcategorias/categorias
    /// </summary>
    public class Auxiliar
    {        
        [DisplayName("Usuário")]
        public int AddUserId { get; set; }

        [DisplayName("Usuário")]
        public int UpdateUserId { get; set; }

        [DisplayName("Inclusão")]
        public DateTime AddDate { get; set; }

        [DisplayName("Data")]
        public DateTime UpdateDate { get; set; }

        [DisplayName("St")]
        public status St { get; set; } 
        
        //public string Image { get; set; }

        /// <summary>
        /// define o tipo de operação: o (operação): "view" (view), "del" (delete)
        /// usado, por exemplo, para invocar os modais
        /// </summary>
        [NotMapped]
        public string TypeOperation { get; set; }

        [DisplayName("Registros")]
        [NotMapped]
        public int RegisterCount { get; set; }
    }

    /// <summary>
    /// nS:notSet (não definido), on (ativo), off (desabilitado)
    /// </summary>
    public enum status
    {
        off, on
    }
}
