using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    public class SubCategory : Auxiliar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*** a categoria é uma informação necessária!!!")]
        [DisplayName("categoria")]
        public int CategoryId { get; set; }

        [DisplayName("nome")]
        public string Name { get; set; }

        [DisplayName("apelido")]
        public string Alias { get; set; }

        [DisplayName("Detalhes")]
        public string Details { get; set; }

        public string FileName { get; set; }

        [NotMapped]
        public Category CategoryObj { get; set; }

        [NotMapped]
        public int LinkedRecords { get; set; }
    }
}
