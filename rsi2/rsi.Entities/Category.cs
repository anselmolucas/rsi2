using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    public class Category : Auxiliar
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Details { get; set; }
        public string FileName { get; set; }

        [NotMapped]
        public List<SubCategory> SubCategoryList { get; set; }

        [NotMapped]
        public int LinkedRecords { get; set; }
    }
}
